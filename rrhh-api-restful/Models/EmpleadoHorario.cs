namespace rrhh_api_restful.Models
{
    public class EmpleadoHorario
    {
        public long IdEmpleado { get; set; }
        public long IdHorario { get; set; }
        
        public virtual Empleado Empleado { get; set; }
        public virtual Horario Horario { get; set; }
    }
}