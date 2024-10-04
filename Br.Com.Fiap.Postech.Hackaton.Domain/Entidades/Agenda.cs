using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Br.Com.Fiap.Postech.Hackaton.Domain.Entidades
{
    [Table("TB_AGENDA")]
    public class Agenda
    {

        [Key]
        [Column("CD_AGENDA")]
        public int Codigo { get; set; }

        [Column("DT_AGENDA")]
        public DateTime Data { get; set; }

        [Column("HR_INICIO")]
        public TimeSpan HoraInicial { get; set; }

        [Column("HR_FIM")]
        public TimeSpan HoraFinal { get; set; }

        [Column("CD_USUARIO_MEDICO")]
        [ForeignKey("FK_AGENDA_MEDICO")]
        public int CodigoMedico { get; set; }

        [Column("CD_USUARIO_PACIENTE")]
        [ForeignKey("FK_AGENDA_PACIENTE")]
        public int? CodigoPaciente { get; set; }
    }
}
