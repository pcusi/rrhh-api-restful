namespace rrhh_api_restful.Models
{
    public class Departamento : IIdIdentity<long>
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public long Capacidad { get; set; }
    }
}