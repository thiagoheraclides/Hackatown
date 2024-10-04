using Br.Com.Fiap.Postech.Hackaton.Domain.Entidades;
using Br.Com.Fiap.Postech.Hackaton.Domain.Interfaces;
using Br.Com.Fiap.Postech.Hackaton.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Br.Com.Fiap.Postech.Hackaton.Application.Services
{
    public class MedicoService(Context data) : IMedicoService
    {
        private readonly Context _data = data;

        public async Task Cadastrar(UsuarioMedico medico)
        {
            var especialidadeExistente = await _data.Especialidades.AnyAsync(especialidade => especialidade.Codigo == medico.CodigoEspecialidade);

            if (!especialidadeExistente)
                await _data.Especialidades.AddAsync(medico.Especialidade);

            await _data.Medicos.AddAsync(medico);

            await _data.SaveChangesAsync();
            
        }

        public async Task CadastrarAgenda(IList<Agenda> horarios)
        {
            await _data.Agendas.AddRangeAsync(horarios);
            await _data.SaveChangesAsync();
        }

        public async Task<IEnumerable<UsuarioMedico>> ObterPorCodigoEspecialidade(int codigo)
        {
            var especializadade = await _data.Especialidades
                .Where(especialidade => especialidade.Codigo == codigo)
                .SingleOrDefaultAsync()
                ?? throw new Exception("Especialidade não encontrada.");

            var medicosPorEspecialidade = await _data.Medicos
                .Include(med => med.Especialidade)
                .Where(medico => medico.Especialidade.Codigo.Equals(codigo)).ToListAsync();

            return medicosPorEspecialidade;

        }
    }
}
