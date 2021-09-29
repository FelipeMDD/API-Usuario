using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using API.Features.Administradores;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {

        [HttpGet("usuarios")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "administrador")]
        public IActionResult ListarUsuarios(
            [FromQuery] ListarUsuarios.Query query,
            [FromServices] ListarUsuarios.QueryHandler handler)
        {
            var result = handler.Handle(query);

            return result.Any() ? (IActionResult)Ok(result) : NoContent();
        }

        [HttpPost("adicionar")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "administrador")]
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
