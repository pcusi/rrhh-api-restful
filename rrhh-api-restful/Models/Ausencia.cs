namespace rrhh_api_restful.Models
{
    public class Ausencia
    {
        public long IdUsuario { get; set; }
        public long IdEmpleado { get; set; }
        public string Estado { get; set; }
        public long FechaCreacion { get; set; }
        public long FechaInicio { get; set; }
        public long FechaFin { get; set; }
        public string Nombre { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Empleado Empleado { get; set; }
    }
}