using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using rrhh_api_restful.DTO.Request.EstadoCivil;
using rrhh_api_restful.DTO.Response.EstadoCivil;
using rrhh_api_restful.Models;
using sintransa_api_restful.Resources;

namespace rrhh_api_restful.Controllers
{
    public class EstadoCivilController : AppController
    {
        public EstadoCivilController(RhDbContext db, IStringLocalizer<SharedResource> stringLocalizer, IConfiguration config) : base(db, stringLocalizer, config)
        {
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> RegistrarEstadoCivil([FromBody] RegistrarEstadoCivilRequest request)
        {
            var estadoCivil = new EstadoCivil
            {
                Nombre = request.Nombre
            };

            _db.EstadoCivil.Add(estadoCivil);

            await _db.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("listar")]
        public async Task<ListarEstadoCivilResponse[]> ListarEstadosCiviles()
        {
            var estadosCiviles = await _db.EstadoCivil
                .Select(ec => new ListarEstadoCivilResponse
            {
                Id = ec.Id,
                Nombre = ec.Nombre
            }).ToArrayAsync();

            return estadosCiviles;
        }
        
        [HttpPut("editar/{idEstCivil}")]
        public async Task<IActionResult> EditarEstadoCivil([FromBody] RegistrarEstadoCivilRequest request, [FromRoute] long idEstCivil)
        {
            var estadoCivil = await _db.EstadoCivil.Where(ec => ec.Id == idEstCivil).SingleOrDefaultAsync();

            estadoCivil.Nombre = request.Nombre;

            await _db.SaveChangesAsync();

            return Ok();
        }
    }
}