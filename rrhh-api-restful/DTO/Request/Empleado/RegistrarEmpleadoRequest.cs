namespace rrhh_api_restful.DTO.Request.Empleado
{
    public class RegistrarEmpleadoRequest
    {
        public bool Activo { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Cargo { get; set; }
        public string Correo { get; set; }
        public string Dni { get; set; }
        public string Direccion { get; set; }
        public long FechaNacimiento { get; set; }
        public string Foto { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public long IdEstCivil { get; set; }
    }
}