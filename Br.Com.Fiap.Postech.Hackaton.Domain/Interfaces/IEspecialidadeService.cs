using Br.Com.Fiap.Postech.Hackaton.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Br.Com.Fiap.Postech.Hackaton.Domain.Interfaces
{
    public interface IEspecialidadeService
    {
        Task<IEnumerable<EspecialidadeMedica>> ObterAsync();
    }
}
