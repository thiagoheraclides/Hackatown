using Br.Com.Fiap.Postech.Hackaton.Domain.Entidades;
using Br.Com.Fiap.Postech.Hackaton.Domain.Interfaces;
using Br.Com.Fiap.Postech.Hackaton.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Br.Com.Fiap.Postech.Hackaton.Application.Services
{
    public class EspecialidadeService(Context data) : IEspecialidadeService
    {
        private readonly Context _data = data;

        public async Task<IEnumerable<EspecialidadeMedica>> ObterAsync() =>
            await _data.Especialidades.ToListAsync();
    }
}
