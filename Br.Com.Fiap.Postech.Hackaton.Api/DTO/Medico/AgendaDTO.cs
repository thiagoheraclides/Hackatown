using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Br.Com.Fiap.Postech.Hackaton.Api.DTO.Medico
{
    public class AgendaDTO
    {
        [Required(ErrorMessage = "O campo código do médico é obrigatório.")]
        public int CodigoMedico { get; set; }

        [Required(ErrorMessage = "A lista de horários disponíveis para atendimento é obrigatória.")]
        public IList<HorarioDisponivelDTO> HorariosDisponiveis { get; set; } = [];
    }
}
