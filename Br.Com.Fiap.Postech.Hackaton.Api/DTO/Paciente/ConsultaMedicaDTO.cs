using System.ComponentModel.DataAnnotations;

namespace Br.Com.Fiap.Postech.Hackaton.Api.DTO.Paciente
{
    public class ConsultaMedicaDTO
    {
        [Required(ErrorMessage = "O campo código do paciente é obrigatório.")]
        public int CodigoPaciente { get; set; }

        [Required(ErrorMessage = "O campo código do horário disponível é obrigatório.")]
        public int CodigoHorarioDisponivel { get; set; }
    }
}
