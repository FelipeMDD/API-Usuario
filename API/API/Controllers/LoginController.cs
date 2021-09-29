using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Infrastructure;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using API.Services;
using System;
using API.Features.Login;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult<dynamic> Authenticate(
            [FromBody] GerarToken.Command command,
            [FromServices] GerarToken.CommandHandler handler)
        {
            return handler
                .Handle(command).Result;     
        }
    }
}
