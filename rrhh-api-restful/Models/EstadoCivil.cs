namespace rrhh_api_restful.Models
{
    public class EstadoCivil : IIdIdentity<long>
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
    }
}