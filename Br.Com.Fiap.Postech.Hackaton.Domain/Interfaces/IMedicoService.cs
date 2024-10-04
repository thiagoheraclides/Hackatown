using Br.Com.Fiap.Postech.Hackaton.Domain.Entidades;

namespace Br.Com.Fiap.Postech.Hackaton.Domain.Interfaces
{
    public interface IMedicoService
    {
        Task Cadastrar(UsuarioMedico medico);

        Task<UsuarioMedico> Obter(string email, string senha);

        Task<IEnumerable<UsuarioMedico>> ObterPorCodigoEspecialidade(int codigo);

        Task CadastrarAgenda(IList<Agenda> Horarios);
    }
}
