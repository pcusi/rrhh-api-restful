using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using rrhh_api_restful.DTO.Request.Departamento;
using rrhh_api_restful.DTO.Response.Departamento;
using rrhh_api_restful.Models;
using sintransa_api_restful.Resources;

namespace rrhh_api_restful.Controllers
{
    public class DepartamentoController : AppController
    {
        public DepartamentoController(RhDbContext db, IStringLocalizer<SharedResource> stringLocalizer, IConfiguration config) : base(db, stringLocalizer, config)
        {
        }
        
        [HttpPost("registrar")]
        public async Task<string> RegistrarDepartamento([FromBody] RegistrarDepartamentoRequest request)
        {
            var departamento = new Departamento
            {
                Nombre = request.Nombre,
                Capacidad = request.Capacidad
            };

            _db.Departamento.Add(departamento);

            await _db.SaveChangesAsync();
            
            return "registrado";
        }

        [HttpGet("listar")]
        public async Task<ListarDepartamentosResponse[]> ListarDepartamentos()
        {
            var departamentos = await _db.Departamento.Select(d => new ListarDepartamentosResponse
            {
                Id = d.Id,
                Nombre = d.Nombre,
                Capacidad = d.Capacidad,
            }).ToArrayAsync();

            return departamentos;
        }

        [HttpPut("editar/{idDepartamento}")]
        public async Task<string> EditarDepartamento([FromBody] RegistrarDepartamentoRequest request, [FromRoute] long idDepartamento)
        {
            var departamento = await _db.Departamento.Where(d => d.Id == idDepartamento).SingleOrDefaultAsync();

            departamento.Nombre = request.Nombre;
            departamento.Capacidad = request.Capacidad;

            await _db.SaveChangesAsync();

            return "editado";
        }
        #region EmpleadoDepartamento
        
        [HttpPost("asignarEmpleado")]
        public async Task<string> RegistrarEmpleadoDepartamento([FromBody] RegistrarEmpleadoDepartamentoRequest request)
        {
            var empleadoDepartamento = new EmpleadoDepartamento
            {
                IdEmpleado = request.IdEmpleado,
                IdDepartamento = request.IdDepartamento,
            };

            _db.EmpleadoDepartamento.Add(empleadoDepartamento);

            await _db.SaveChangesAsync();
            
            return "registrado";
        }
        
        [HttpGet("listarAsignados")]
        public async Task<ListarEmpleadosDepartamentoResponse[]> ListarAsignadosPorDepartamento()
        {
            var asignados = await _db.EmpleadoDepartamento.Select(d => new ListarEmpleadosDepartamentoResponse
            {
                IdEmpleado = d.IdEmpleado,
                IdDepartamento = d.IdDepartamento
            }).ToArrayAsync();

            return asignados;
        }
        
        #endregion
    }
}