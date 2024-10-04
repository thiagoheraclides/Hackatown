using Br.Com.Fiap.Postech.Hackaton.Domain.Entidades;
using Br.Com.Fiap.Postech.Hackaton.Domain.Interfaces;
using Br.Com.Fiap.Postech.Hackaton.Infra.Data;
using Microsoft.EntityFrameworkCore;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.EntityFrameworkCore.Storage;

namespace Br.Com.Fiap.Postech.Hackaton.Application.Services
{
    public class PacienteService(Context data) : IPacienteService
    {
        private readonly Context _data = data;

        public async Task Agendar(int codigoPaciente, int codigoHorarioDisponível, SemaphoreSlim semaphoreSlim)
        { 

            await semaphoreSlim.WaitAsync();

            Thread.Sleep(10000);

            var paciente = await _data.Pacientes
                .Where(pct => pct.Id == codigoPaciente)
                .FirstOrDefaultAsync()
                ?? throw new Exception("Paciente não localizado.");

            var horarioDisponivel = await _data.Agendas
                .Where(a => a.Codigo == codigoHorarioDisponível)
                .FirstOrDefaultAsync();

            if (horarioDisponivel is null || horarioDisponivel.CodigoPaciente is not null)
                throw new Exception("Horário não disponível para agendamento");

            horarioDisponivel.CodigoPaciente = codigoPaciente;

            var medico = await _data.Medicos
                .Where(med => med.Id == horarioDisponivel!.CodigoMedico)
                .FirstOrDefaultAsync()
                ?? throw new Exception("Paciente não localizado.");
         
            await _data.SaveChangesAsync();

            EnviarEmail(medico, paciente, horarioDisponivel);

            semaphoreSlim.Release();
        }

        public async Task Cadastrar(UsuarioPaciente paciente)
        {

            var pacienteExistente = await _data.Pacientes
                .Where(pct => pct.CPF.Equals(paciente.CPF))
                .FirstOrDefaultAsync();

            if (pacienteExistente is not null)
                throw new Exception($"O paciente identificado pelo CPF {paciente.CPF} já encontra-se cadastrado em banco de dados.");


            await _data.Pacientes.AddAsync(paciente);
            await _data.SaveChangesAsync();
        }

        public async Task<IList<Agenda>> Obter(int codigoMedico, DateTime data)
        {
            return await _data.Agendas.Where(a => a.CodigoMedico == codigoMedico 
                && a.Data == data.Date && a.CodigoPaciente == null).ToListAsync();
        }

        public async Task<UsuarioPaciente> Obter(string email, string senha)
        {
            var paciente = await _data.Pacientes
                .Where(med => med.Email == email && med.Senha == senha)
                .FirstOrDefaultAsync()
                ?? throw new Exception("Usuário não encontrado.");

            return paciente;
        }

        private static void EnviarEmail(UsuarioMedico usuarioMedico, UsuarioPaciente usuarioPaciente, Agenda agenda)
        {
            using var email = new MimeMessage();
            email.From.Add(new MailboxAddress("Sender E-mail", "sender@demomailtrap.com"));
            email.To.Add(new MailboxAddress(usuarioMedico.Nome, usuarioMedico.Email));

            email.Subject = "Health&Med - Nova consulta agendada";

            var builder = new BodyBuilder()
            {
                TextBody = $"Olá, Dr. {usuarioMedico.Nome}!{Environment.NewLine}Você tem uma nova consulta marcada! " +
                    $"Paciente: {usuarioPaciente.Nome}.{Environment.NewLine}Data e horário: {agenda.Data:dd/MM/yyyy} às {agenda.HoraInicial}."
            };

            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
            smtp.Connect("sandbox.smtp.mailtrap.io", 2525, false);

            smtp.Authenticate("ef292348a12c45", "0f7957b796f63f");

            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
