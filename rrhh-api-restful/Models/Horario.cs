namespace rrhh_api_restful.Models
{
    public class Horario : IIdIdentity<long>
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public long HoraEntrada { get; set; }
        public long HoraSalida { get; set; }
    }
}