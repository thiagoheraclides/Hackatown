using Br.Com.Fiap.Postech.Hackaton.Domain.Entidades;

namespace Br.Com.Fiap.Postech.Hackaton.Domain.Interfaces
{
    public interface IEmailService
    {
        void EnviarEmail(UsuarioMedico usuarioMedico, UsuarioPaciente usuarioPaciente, Agenda agenda);
    }
}
