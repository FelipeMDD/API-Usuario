using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using API.Features.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using API.Features.Administradores;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "administrador, usuario")]
        public IActionResult ListarUsuarios(
            [FromRoute] VerificarCadastro.Query query,
            [FromServices] VerificarCadastro.QueryHandler handler)
        {
            var result = handler.Handle(query);

            return result.Any() ? Ok(result) : NoContent();
        }

        [HttpPost("alterar")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "administrador, usuario")]
        public IActionResult AlterarSenha(
           [FromBody] AlterarSenha.Command command,
           [FromServices] AlterarSenha.CommandHandler handler)
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
