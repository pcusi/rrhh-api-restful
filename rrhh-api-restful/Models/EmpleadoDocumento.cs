namespace rrhh_api_restful.Models
{
    public class EmpleadoDocumento
    {
        public long IdEmpleado { get; set; }
        public long IdDocumento { get; set; }
        public string Estado { get; set; }
        public string Firmado { get; set; }
        public long FechaEnvio { get; set; }

        public virtual Empleado Empleado { get; set; }
        public virtual Documento Documento { get; set; }
    }
}