namespace rrhh_api_restful.DTO.Request.Usuario
{
    public class RegistrarUsuarioRequest
    {
        public string Clave { get; set; }
        public string Correo { get; set; }
        public long IdEmpleado { get; set; }
    }
}