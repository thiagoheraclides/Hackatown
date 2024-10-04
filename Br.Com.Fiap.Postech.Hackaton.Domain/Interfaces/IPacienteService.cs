using Br.Com.Fiap.Postech.Hackaton.Domain.Entidades;

namespace Br.Com.Fiap.Postech.Hackaton.Domain.Interfaces
{
    public interface IPacienteService
    {
        Task Cadastrar(UsuarioPaciente usuarioPaciente);

        Task<UsuarioPaciente> Obter(string email, string senha);

        Task<IList<Agenda>> Obter(int codigoMedico, DateTime data);

        Task Agendar(int codigoPaciente, int codigoHorarioDisponível);
    }
}
