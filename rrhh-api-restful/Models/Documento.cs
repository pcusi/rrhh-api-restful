namespace rrhh_api_restful.Models
{
    public class Documento : IIdIdentity<long>
    {
        public long Id { get; set; }
        public long IdUsuario { get; set; }
        public string Archivo { get; set; }
        public long FechaCreacion { get; set; }
        public long FechaModificacion { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}