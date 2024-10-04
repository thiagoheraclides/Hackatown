using Br.Com.Fiap.Postech.Hackaton.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Br.Com.Fiap.Postech.Hackaton.Infra.Data
{
    public class Context(DbContextOptions<Context> options) : DbContext(options)
    {
        public DbSet<UsuarioMedico> Medicos { get; set; }

        public DbSet<EspecialidadeMedica> Especialidades { get; set; }

        public DbSet<UsuarioPaciente> Pacientes { get; set; }

        public DbSet<Agenda> Agendas { get; set; }

    }
}
