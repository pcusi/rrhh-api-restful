namespace rrhh_api_restful.Models
{
    public class EmpleadoDepartamento
    {
        public long IdEmpleado { get; set; }
        public long IdDepartamento { get; set; }
        
        public virtual Empleado Empleado { get; set; }
        public virtual Departamento Departamento { get; set; }
    }
}