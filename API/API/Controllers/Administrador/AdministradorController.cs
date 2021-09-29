using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using API.Features.Administradores;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {

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
