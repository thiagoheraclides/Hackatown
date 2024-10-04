using Br.Com.Fiap.Postech.Hackaton.Domain.Entidades;

namespace Br.Com.Fiap.Postech.Hackaton.Domain.Interfaces
{
    public interface ITokenService
    {
        string GetToken(UsuarioPaciente paciente);

        string GetToken(UsuarioMedico medico);
    }
}
