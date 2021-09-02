using Microsoft.EntityFrameworkCore;
using rrhh_api_restful.Models.Extensions;

namespace rrhh_api_restful.Models
{
    public class RhDbContext : DbContext
    {
        public RhDbContext(DbContextOptions<RhDbContext> options) : base(options) { }
        
        //entidades
        public DbSet<EstadoCivil> EstadoCivil { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Ausencia> Ausencia { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<EmpleadoDepartamento> EmpleadoDepartamento { get; set; }
        public DbSet<Documento> Documento { get; set; }
        public DbSet<EmpleadoDocumento> EmpleadoDocumento { get; set; }
        public DbSet<Horario> Horario { get; set; }
        public DbSet<EmpleadoHorario> EmpleadoHorario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Ausencia>(entity =>
            {
                entity.ToTable(nameof(Ausencia));
                entity.Property(e => e.Nombre).IsRequiredVariableLengthString(50, false);
                entity.Property(e => e.Estado).IsRequiredVariableLengthString(1, false);
                entity.MapearUnoMuchosUnidireccional(e => e.Empleado,  e => e.IdEmpleado);
                entity.MapearUnoMuchosUnidireccional(e => e.Usuario,  
                    e => e.IdUsuario);
                entity.HasNoKey();
            });
            
            builder.Entity<EstadoCivil>(entity =>
            {
                entity.ToTable(nameof(EstadoCivil));
                entity.Property(e => e.Nombre).IsRequiredVariableLengthString(25, false);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasKey(e => e.Id);
            });

            builder.Entity<Empleado>(entity =>
            {
                entity.ToTable(nameof(Empleado));
                entity.Property(e => e.Nombre).IsRequiredVariableLengthString(50, false);
                entity.Property(e => e.ApellidoPaterno).IsRequiredVariableLengthString(50, false);
                entity.Property(e => e.ApellidoMaterno).IsRequiredVariableLengthString(50, false);
                entity.Property(e => e.Dni).IsRequiredVariableLengthString(8, false);
                entity.Property(e => e.Direccion).IsVariableLengthString(200, false);
                entity.Property(e => e.Telefono).IsVariableLengthString(9, false);
                entity.Property(e => e.Cargo).IsVariableLengthString(30, false);
                entity.Property(e => e.Correo).IsVariableLengthString(30, false);
                entity.Property(e => e.Foto).IsVariableLengthString(200, false);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasKey(e => e.Id);
                entity.MapearUnoUnoUnidireccional(e => e.EstadoCivil, e => e.IdEstCivil);
            });

            builder.Entity<Departamento>(entity =>
            {
                entity.ToTable(nameof(Departamento));
                entity.Property(e => e.Nombre).IsRequiredVariableLengthString(50, false);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasKey(e => e.Id);
            });

            builder.Entity<EmpleadoDepartamento>(entity =>
            {
                entity.ToTable(nameof(EmpleadoDepartamento));
                entity.MapearUnoMuchosUnidireccional(e => e.Empleado,  e => e.IdEmpleado);
                entity.MapearUnoMuchosUnidireccional(e => e.Departamento,  
                    e => e.IdDepartamento);
                entity.HasNoKey();
            });

            builder.Entity<Documento>(entity =>
            {
                entity.ToTable(nameof(Documento));
                entity.Property(e => e.Nombre).IsRequiredVariableLengthString(50, false);
                entity.Property(e => e.Archivo).IsRequiredVariableLengthString(200, false);
                entity.Property(e => e.Tipo).IsRequiredVariableLengthString(20, false);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasKey(e => e.Id);
                entity.MapearUnoMuchosUnidireccional(e => e.Usuario, e => e.IdUsuario);
            });

            builder.Entity<EmpleadoDocumento>(entity =>
            {
                entity.ToTable(nameof(EmpleadoDocumento));
                entity.Property(e => e.Estado).IsRequiredVariableLengthString(1, false);
                entity.Property(e => e.Firmado).IsRequiredVariableLengthString(100, false);
                entity.MapearUnoMuchosUnidireccional(e => e.Empleado,  e => e.IdEmpleado);
                entity.MapearUnoMuchosUnidireccional(e => e.Documento,  
                    e => e.IdDocumento);
                entity.HasNoKey();
            });

            builder.Entity<Horario>(entity =>
            {
                entity.ToTable(nameof(Horario));
                entity.Property(e => e.Nombre).IsRequiredVariableLengthString(50, false);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasKey(e => e.Id);
            });

            builder.Entity<EmpleadoHorario>(entity =>
            {
                entity.ToTable(nameof(EmpleadoHorario));
                entity.MapearUnoMuchosUnidireccional(e => e.Empleado,  e => e.IdEmpleado);
                entity.MapearUnoMuchosUnidireccional(e => e.Horario,  
                    e => e.IdHorario);
                entity.HasNoKey();
            });

            builder.Entity<Usuario>(entity =>
            {
                entity.ToTable(nameof(Usuario));
                entity.Property(e => e.Correo).IsRequiredVariableLengthString(30, false);
                entity.Property(e => e.Clave).IsRequiredVariableLengthString(200, false);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasKey(e => e.Id);
                entity.MapearUnoUnoUnidireccional(e => e.Empleado, e => e.IdEmpleado);
            });
        }
    }
}