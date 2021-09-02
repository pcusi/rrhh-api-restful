namespace rrhh_api_restful.DTO.Response.Usuario
{
    public class ListarUsuariosResponse
    {
        public long Id { get; set; }
        public string Clave { get; set; }
        public string Correo { get; set; }
        public long IdEmpleado { get; set; }
    }
}