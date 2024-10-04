using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Br.Com.Fiap.Postech.Hackaton.Domain.Entidades
{
    public class Consulta
    {
        //Identificador único da consulta
        public int? Id { get; set; }

        //Referência do medico da consulta
        public int? MedicoId { get; set; }

        //Referência do paciente da consulta
        public int? PacienteId { get; set; }

        //Referência ao horario disponivel e agendamento do medico com o identificação da duração da consulta
        public int? AgendaEspecialistaId { get; set; }

        //Data e hora em que a transação foi efetuada
        public DateTime? DataSolicitacao { get; set; }
    }
}
