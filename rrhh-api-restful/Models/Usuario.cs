namespace rrhh_api_restful.Models
{
    public class Usuario : IIdIdentity<long>
    {
        public long Id { get; set; }
        public string Clave { get; set; }
        public string Correo { get; set; }
        public long IdEmpleado { get; set; }
        
        public virtual Empleado Empleado { get; set; }
    }
}