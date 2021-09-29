using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Infrastructure;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using API.Services;
using System;
using API.Features.Administradores;

namespace API.Controllers.Administrador
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {
        private readonly Context _context;

        public AdministradorController(Context context)
        {
            _context = context;
        }

        [HttpGet("usuarios")]
        [AllowAnonymous]
        public IActionResult ListarUsuarios(
            [FromQuery] ListarUsuarios.Query query,
            [FromServices] ListarUsuarios.QueryHandler handler)
        {
            var result = handler.Handle(query);

            return result.Any() ? (IActionResult)Ok(result) : NoContent();
        }

        [HttpPost("ativar")]
        public IActionResult AdicionarNovoUsuario(
           [FromBody] AdicionarUsuario.Command command,
           [FromServices] AdicionarUsuario.CommandHandler handler)
        {
            return handler
                .Handle(command)
                .Match<IActionResult>(
                Ok: () => Ok(),
                Err: e => BadRequest(e)
            );
        }

    }
}
