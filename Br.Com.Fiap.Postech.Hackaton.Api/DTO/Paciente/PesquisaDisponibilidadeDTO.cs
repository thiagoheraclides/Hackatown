using System.ComponentModel.DataAnnotations;

namespace Br.Com.Fiap.Postech.Hackaton.Api.DTO.Paciente
{
    public class PesquisaDisponibilidadeDTO
    {
        [Required(ErrorMessage = "O campo código do médico é obrigatório.")]
        public int CodigoMedico { get; set; }

        [Required(ErrorMessage = "O campo data é obrigatório.")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
    }
}
