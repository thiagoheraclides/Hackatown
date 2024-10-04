using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Br.Com.Fiap.Postech.Hackaton.Domain.Entidades
{
    [Table("TB_USUARIO_MEDICO")]
    public class UsuarioMedico
    {
        //Identificador único do usuário medico
        [Key]
        [Column("CD_USUARIO_MEDICO")]
        public int? Id { get; set; }

        //Nome completo do usuário medico
        [Column("NM_USUARIO_MEDICO")]
        public string Nome { get; set; } = null!;

        //Email do usuário medico
        [Column("DS_EMAIL_MEDICO")]
        public string Email { get; set; } = null!;

        //CPF do usuário medico
        [Column("NR_CPF_MEDICO")]
        public string CPF { get; set; } = null!;

        //CRM do usuário medico
        [Column("NR_CRM_MEDICO")]
        public string CRM { get; set; } = null!;

        //Hash da senha para autenticação
        [Column("DS_SENHA_MEDICO")]
        public string Senha { get; set; } = null!;

        [Column("CD_ESPECIALIDADE")]
        [ForeignKey("Especialidade")]
        public int CodigoEspecialidade { get; set; }
        
        public EspecialidadeMedica Especialidade { get; set; } = null!;
    }
}
