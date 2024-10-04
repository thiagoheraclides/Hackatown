using Br.Com.Fiap.Postech.Hackaton.Domain.Entidades;
using Br.Com.Fiap.Postech.Hackaton.Domain.Interfaces;
using Br.Com.Fiap.Postech.Hackaton.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Br.Com.Fiap.Postech.Hackaton.Application.Services
{
    public class PacienteService(Context data) : IPacienteService
    {
        private readonly Context _data = data;

        public async Task Agendar(int codigoPaciente, int codigoHorarioDisponível)
        {
            var paciente = await _data.Pacientes
                .Where(pct => pct.Id == codigoPaciente)
                .FirstOrDefaultAsync()
                ?? throw new Exception("Paciente não localizado.");

            var horarioDisponivel = await _data.Agendas.Where(a => a.Codigo == codigoHorarioDisponível).FirstOrDefaultAsync();

            if (horarioDisponivel is null || horarioDisponivel.CodigoPaciente is not null)
                throw new Exception("Horário não disponível para agendamento");

            horarioDisponivel.CodigoPaciente = codigoPaciente;           
            await _data.SaveChangesAsync();
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
    }
}
