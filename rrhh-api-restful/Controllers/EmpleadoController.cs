using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using rrhh_api_restful.DTO.Request.Empleado;
using rrhh_api_restful.DTO.Response.Empleado;
using rrhh_api_restful.Models;
using sintransa_api_restful.Resources;

namespace rrhh_api_restful.Controllers
{
    public class EmpleadoController : AppController
    {
        public EmpleadoController(RhDbContext db, IStringLocalizer<SharedResource> stringLocalizer, IConfiguration config) : base(db, stringLocalizer, config)
        {
        }

        [Authorize]
        [HttpPost("registrar")]
        public async Task<string> RegistrarEmpleado([FromBody] RegistrarEmpleadoRequest request)
        {
            var empleado = new Empleado
            {
                Nombre = request.Nombre,
                ApellidoPaterno = request.ApellidoPaterno,
                ApellidoMaterno = request.ApellidoMaterno,
                Cargo = request.Cargo,
                Correo = request.Correo,
                Dni = request.Dni,
                Direccion = request.Direccion,
                FechaNacimiento = request.FechaNacimiento,
                Activo = true,
                Telefono = request.Telefono,
                IdEstCivil = request.IdEstCivil
            };

            _db.Empleado.Add(empleado);
            
            await _db.SaveChangesAsync();
            
            return "registrado";
        }

        [Authorize]
        [HttpGet("listar")]
        public async Task<ListarEmpleadosResponse[]> ListarEmpleados()
        {
            var empleados = await _db.Empleado.Select(e => new ListarEmpleadosResponse
            {
                Id = e.Id,
                Nombre = e.Nombre,
                ApellidoPaterno = e.ApellidoPaterno,
                ApellidoMaterno = e.ApellidoMaterno,
                Cargo = e.Cargo,
                Correo = e.Correo,
                Dni = e.Dni,
                Direccion = e.Direccion,
                FechaNacimiento = e.FechaNacimiento,
                Activo = e.Activo,
                Telefono = e.Telefono,
                Foto = e.Foto,
                IdEstCivil = e.IdEstCivil
            }).ToArrayAsync();

            return empleados;
        }
        
        [Authorize]
        [HttpPut("editar/{idEmpleado}")]
        public async Task<string> EditarEmpleado([FromBody] RegistrarEmpleadoRequest request, [FromRoute] long idEmpleado)
        {

            var empleado = await _db.Empleado.Where(e => e.Id == idEmpleado).SingleOrDefaultAsync();

            empleado.Nombre = request.Nombre;
            empleado.ApellidoPaterno = request.ApellidoPaterno;
            empleado.ApellidoMaterno = request.ApellidoMaterno;
            empleado.Cargo = request.Cargo;
            empleado.Correo = request.Correo;
            empleado.Dni = request.Dni;
            empleado.Direccion = request.Direccion;
            empleado.FechaNacimiento = request.FechaNacimiento;
            empleado.Telefono = request.Telefono;
            empleado.IdEstCivil = request.IdEstCivil;

            await _db.SaveChangesAsync();
            
            return "editado";
        }
        
        [Authorize]
        [HttpGet("activar")]
        public async Task<string> ActivarEmpleado([FromRoute] long idEmpleado)
        {

            var empleado = await _db.Empleado.Where(e => e.Id == idEmpleado).SingleOrDefaultAsync();

            empleado.Activo = !empleado.Activo;

            await _db.SaveChangesAsync();
            
            return empleado.Activo ? "activado" : "desactivado";
        }
    }
}