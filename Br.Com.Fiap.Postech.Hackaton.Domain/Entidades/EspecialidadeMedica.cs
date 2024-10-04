using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Br.Com.Fiap.Postech.Hackaton.Domain.Entidades
{
    [Table("TB_ESPECIALIDADE")]
    public class EspecialidadeMedica
    {
        [Key]
        [Column("CD_ESPECIALIDADE")]
        public int Codigo { get; set; }

        [Column("DS_ESPECIALIDADE")]
        public string Descricao { get; set; } = null!;

        public ICollection<UsuarioMedico> Medicos { get; set; } = null!;
    }
}
