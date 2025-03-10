using Microsoft.EntityFrameworkCore;
using proyecto.Domain;

namespace proyecto.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Asistente> Asistentes { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Expediente> Expedientes { get; set; }
        public DbSet<Recordatorio> Recordatorios { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Usuario>();
            //.Property(u => u.Rol)
            //.HasConversion<string>()
            //.HasMaxLength(50)
            //.HasCheckConstraint("CK_Usuario_Rol", "Rol IN ('Admin', 'Medico', 'Asistente')");

            modelBuilder.Entity<Paciente>();
            //.Property(p => p.Genero)
            //.HasMaxLength(1)
            //.HasCheckConstraint("CK_Paciente_Genero", "Genero IN ('M', 'F')");

            modelBuilder.Entity<Cita>();
                //.Property(c => c.Estado)
                //.HasConversion<string>()
                //.HasMaxLength(50)
                //.HasCheckConstraint("CK_Cita_Estado", "Estado IN ('Pendiente', 'Confirmada', 'Cancelada')");
        }
    }
}
