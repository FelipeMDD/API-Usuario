using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Infrastructure;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using API.Services;
using System;
using API.Features.Usuarios;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet("resumo")]
        [AllowAnonymous]
        public IActionResult VerificarCadastro(
            [FromBody] VerificarCadastro.Query query,
            [FromServices] VerificarCadastro.QueryHandler handler)
        {
            var result = handler.Handle(query);

            return result.Any() ? (IActionResult)Ok(result) : NoContent();
        }

        [HttpPost("alterarsenha")]
        [AllowAnonymous]
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
