using System.ComponentModel.DataAnnotations;

namespace Br.Com.Fiap.Postech.Hackaton.Api.DTO.Medico
{
    public class HorarioDisponivelDTO
    {
        [Required(ErrorMessage = "O campo hora de ínicio da consulta é obrigatório.")]
        public DateTime HoraInicial { get; set; }

        [Required(ErrorMessage = "O campo hora de fim da consulta é obrigatório.")]
        public DateTime HoraFinal { get; set; }
    }
}
