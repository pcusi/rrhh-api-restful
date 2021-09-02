using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using rrhh_api_restful.DTO.Request.Usuario;
using rrhh_api_restful.DTO.Response.Usuario;
using rrhh_api_restful.Models;
using sintransa_api_restful.Resources;

namespace rrhh_api_restful.Controllers
{
    public class UsuarioController : AppController
    {
        
        public UsuarioController(RhDbContext db, IStringLocalizer<SharedResource> stringLocalizer, IConfiguration config) : base(db, stringLocalizer, config)
        {
        }

        [AllowAnonymous]
        [HttpPost("acceder")]
        public async Task<TokenResponse> Acceder([FromBody] TokenRequest request)
        {
            string token = null;

            var usuario = await _db.Usuario.Where(u => u.Correo == request.Correo).SingleOrDefaultAsync();

            if (usuario != null)
            {

                var autenticado = BCrypt.Net.BCrypt.Verify(request.Clave, usuario.Clave);

                if (autenticado)
                {
                    var secretKey = _config.GetValue<string>("SecretKey");
                    var key = Encoding.ASCII.GetBytes(secretKey);
                    var claims = new ClaimsIdentity();
                    claims.AddClaim(new Claim("Id", usuario.Id.ToString()));

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = claims,
                        Expires = DateTime.UtcNow.AddDays(30),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var createdToken = tokenHandler.CreateToken(tokenDescriptor);
                    token = tokenHandler.WriteToken(createdToken);
                }
                else
                {
                    throw Error(_stringLocalizer["ClaveError"], 403);
                }
            }
            else
            {
                throw Error(_stringLocalizer["UsuarioNoEncontrado"], 400);
            }

            return new TokenResponse
            {
                Token = token
            };

        }
        
        [Authorize]
        [HttpPost("registrar")]
        public async Task<string> RegistrarUsuario([FromBody] RegistrarUsuarioRequest request)
        {

            var hashClave = BCrypt.Net.BCrypt.HashPassword(request.Clave);
            
            var usuario = new Usuario
            {
                Correo = request.Correo,
                Clave = hashClave,
                IdEmpleado = request.IdEmpleado
            };

            _db.Usuario.Add(usuario);

            await _db.SaveChangesAsync();
            
            return "registrado";
        }

        [Authorize]
        [HttpGet("listar")]
        public async Task<ListarUsuariosResponse[]> ListarUsuarios()
        {
            var usuarios = await _db.Usuario.Select(u => new ListarUsuariosResponse
            {
                Id = u.Id,
                Correo = u.Correo,
                Clave = u.Clave,
                IdEmpleado = u.IdEmpleado
            }).ToArrayAsync();

            return usuarios;
        }

        [Authorize]
        [HttpPut("editar/{idUsuario}")]
        public async Task<string> EditarUsuario([FromBody] RegistrarUsuarioRequest request, [FromRoute] long idUsuario)
        {
            var usuario = await _db.Usuario.Where(u => u.Id == idUsuario).SingleOrDefaultAsync();

            usuario.Correo = request.Correo;
            usuario.Clave = request.Clave;
            usuario.IdEmpleado = request.IdEmpleado;

            await _db.SaveChangesAsync();

            return "editado";
        }
    }
}