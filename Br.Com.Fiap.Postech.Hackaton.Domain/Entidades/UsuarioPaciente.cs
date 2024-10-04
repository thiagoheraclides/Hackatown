using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Br.Com.Fiap.Postech.Hackaton.Domain.Entidades
{
    [Table("TB_USUARIO_PACIENTE")]
    public class UsuarioPaciente
    {
        //Identificador único do usuário paciente
        [Key]
        [Column("CD_USUARIO_PACIENTE")]
        public int Id { get; set; }

        //Nome completo do usuário paciente
        [Column("NM_USUARIO_PACIENTE")]
        public string Nome { get; set; } = null!;

        //Email do usuário paciente
        [Column("DS_EMAIL_PACIENTE")]
        public string Email { get; set; } = null!;

        //CPF do usuário paciente
        [Column("NR_CPF_PACIENTE")]
        public string CPF { get; set; } = null!;

        //Hash da senha para autenticação
        [Column("DS_SENHA_PACIENTE")]
        public string Senha { get; set; } = null!;
    }
}
