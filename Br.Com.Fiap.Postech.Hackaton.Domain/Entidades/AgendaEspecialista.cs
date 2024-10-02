using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Br.Com.Fiap.Postech.Hackaton.Domain.Entidades
{
    public partial class AgendaEspecialista
    {
        //Identificador único do agenda do especialista
        public int? Id { get; set; }

        //Referência ao usuário horario incial da consulta
        public DateTime? HoraInicial { get; set; }

        //Referência ao usuário tempo de consulta
        public int? TempoConsulta { get; set; }

        //Referência ao usuário medico especialista da consulta
        public string MedicoId { get; set; }
    }
}
