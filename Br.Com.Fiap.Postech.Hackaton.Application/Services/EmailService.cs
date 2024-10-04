using Br.Com.Fiap.Postech.Hackaton.Domain.Entidades;
using Br.Com.Fiap.Postech.Hackaton.Domain.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;

namespace Br.Com.Fiap.Postech.Hackaton.Application.Services
{
    public class EmailService : IEmailService
    {
        public void EnviarEmail(UsuarioMedico usuarioMedico, UsuarioPaciente usuarioPaciente, Agenda agenda)
        {

            using var email = new MimeMessage();
            email.From.Add(new MailboxAddress(usuarioPaciente.Nome, usuarioPaciente.Email));
            email.To.Add(new MailboxAddress(usuarioMedico.Nome, usuarioMedico.Email));

            email.Subject = "Health&Med - Nova consulta agendada";

            var builder = new BodyBuilder()
            {
                TextBody = $"Olá, Dr. {usuarioMedico.Nome}!\r\nVocê tem uma nova consulta marcada! " +
                    $"Paciente: {usuarioPaciente.Nome}.\r\nData e horário: {agenda.Data:dd/MM/yyyy} às {agenda.HoraInicial:HH:mm:ss}."
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
