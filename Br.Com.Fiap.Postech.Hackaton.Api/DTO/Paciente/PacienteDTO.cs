using System.ComponentModel.DataAnnotations;

namespace Br.Com.Fiap.Postech.Hackaton.Api.DTO.Paciente
{
    public class PacienteDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo nome é obrigatório.")]
        [StringLength(300, ErrorMessage = "O conteudo do campo nome não atende os requisitos de tamanho, mínimo ({2} caracteres) ou maximo ({1} caracteres)", MinimumLength = 6)]
        public string Nome { get; set; } = null!;

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo cpf é obrigatório.")]
        [StringLength(11, ErrorMessage = "O conteudo do campo cpf não atende os requisitos de tamanho, mínimo ({2} caracteres) ou maximo ({1} caracteres)", MinimumLength = 11)]
        public string Cpf { get; set; } = null!;

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo email é obrigatório.")]
        [StringLength(100, ErrorMessage = "O conteudo do campo email não atende os requisitos de tamanho, mínimo ({2} caracteres) ou maximo ({1} caracteres)", MinimumLength = 6)]
        [EmailAddress(ErrorMessage = "O conteúdo do campo email não é reconhecido como um e-mail válido.")]
        public string Email { get; set; } = null!;

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo senha é obrigatório.")]
        [StringLength(18, ErrorMessage = "O conteudo do campo senha não atende os requisitos de tamanho, mínimo ({2} caracteres) ou maximo ({1} caracteres)", MinimumLength = 6)]
        public string Senha { get; set; } = null!;
    }
}
