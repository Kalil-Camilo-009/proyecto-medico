using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public partial class PlataformaDeReservasDeConsultasMedicasContext : DbContext
{
    public PlataformaDeReservasDeConsultasMedicasContext()
    {
    }

    public PlataformaDeReservasDeConsultasMedicasContext(DbContextOptions<PlataformaDeReservasDeConsultasMedicasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asistente> Asistentes { get; set; }

    public virtual DbSet<Cita> Citas { get; set; }

    public virtual DbSet<Expediente> Expedientes { get; set; }

    public virtual DbSet<Medico> Medicos { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Recordatorio> Recordatorios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
        if(!optionsBuilder.IsConfigured)
        { 
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-773V5TO\\SQLEXPRESS;Database=Plataforma_de_Reservas_de_Consultas_Medicas;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asistente>(entity =>
        {
            entity.HasKey(e => e.IdAsistente).HasName("PK__Asistent__128733A5BF90A3C2");

            entity.HasIndex(e => e.IdUsuario, "UQ__Asistent__63C76BE3DC5430BD").IsUnique();

            entity.Property(e => e.IdAsistente).HasColumnName("Id_Asistente");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaDeRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Fecha_de_Registro");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithOne(p => p.Asistente)
                .HasForeignKey<Asistente>(d => d.IdUsuario)
                .HasConstraintName("FK__Asistente__Id_Us__5812160E");
        });

        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.IdCita).HasName("PK__Citas__A95AFC07F2955518");

            entity.Property(e => e.IdCita).HasColumnName("Id_Cita");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaDeCita)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_de_Cita");
            entity.Property(e => e.IdMedico).HasColumnName("Id_Medico");
            entity.Property(e => e.IdPaciente).HasColumnName("Id_Paciente");
            entity.Property(e => e.Observaciones).HasColumnType("text");

            entity.HasOne(d => d.IdMedicoNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdMedico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Citas__Id_Medico__5CD6CB2B");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Citas__Id_Pacien__5BE2A6F2");
        });

        modelBuilder.Entity<Expediente>(entity =>
        {
            entity.HasKey(e => e.IdExpediente).HasName("PK__Expedien__7892EDE6F0CD0204");

            entity.Property(e => e.IdExpediente).HasColumnName("Id_Expediente");
            entity.Property(e => e.Diagnostico).HasColumnType("text");
            entity.Property(e => e.FechaDeCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Fecha_de_Creacion");
            entity.Property(e => e.IdPaciente).HasColumnName("Id_Paciente");
            entity.Property(e => e.Tratamiento).HasColumnType("text");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.Expedientes)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Expedient__Id_Pa__60A75C0F");
        });

        modelBuilder.Entity<Medico>(entity =>
        {
            entity.HasKey(e => e.IdMedico).HasName("PK__Medicos__7BA5D8104A1F2163");

            entity.HasIndex(e => e.IdUsuario, "UQ__Medicos__63C76BE36346807A").IsUnique();

            entity.Property(e => e.IdMedico).HasColumnName("Id_Medico");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Especialidad)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaDeRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Fecha_de_Registro");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NumeroDeLicencia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Numero_de_Licencia");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithOne(p => p.Medico)
                .HasForeignKey<Medico>(d => d.IdUsuario)
                .HasConstraintName("FK__Medicos__Id_Usua__534D60F1");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.IdPaciente).HasName("PK__Paciente__032CD4A654DCFF67");

            entity.Property(e => e.IdPaciente).HasColumnName("Id_Paciente");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaDeNacimiento).HasColumnName("Fecha_de_Nacimiento");
            entity.Property(e => e.FechaDeRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Fecha_de_Registro");
            entity.Property(e => e.Genero)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Recordatorio>(entity =>
        {
            entity.HasKey(e => e.IdRecordatorio).HasName("PK__Recordat__D3289A4AACB7B4F6");

            entity.Property(e => e.IdRecordatorio).HasColumnName("Id_Recordatorio");
            entity.Property(e => e.FechaDeEnvio)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_de_Envio");
            entity.Property(e => e.IdCita).HasColumnName("Id_Cita");
            entity.Property(e => e.Mensaje).HasColumnType("text");

            entity.HasOne(d => d.IdCitaNavigation).WithMany(p => p.Recordatorios)
                .HasForeignKey(d => d.IdCita)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Recordato__Id_Ci__6383C8BA");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__63C76BE2CF460025");

            entity.HasIndex(e => e.NombreDeUsuario, "UQ__Usuarios__494B992AEF883423").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");
            entity.Property(e => e.Clave)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.NombreDeUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_de_Usuario");
            entity.Property(e => e.Rol)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
