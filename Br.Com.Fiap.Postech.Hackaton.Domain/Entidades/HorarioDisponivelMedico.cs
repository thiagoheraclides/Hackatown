using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Br.Com.Fiap.Postech.Hackaton.Domain.Entidades
{
    public partial class HorarioDisponivelMedico
    {
        //Identificador único do horario disponivel
        public int? Id { get; set; }

        //Horario de entrada
        public DateTime? HoraEntrada { get; set; }

        //Horario de saida
        public DateTime? HoraSaida { get; set; }

        //Data da disponibilidade
        public Date? Data { get; set; }

        //Código do medico
        public int? MedicoId { get; set; }
    }
}
