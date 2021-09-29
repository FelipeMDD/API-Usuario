using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Infrastructure;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using API.Services;
using System;
using API.Features.Administradores;

namespace API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult<dynamic> Authenticate([FromBody] Acesso login)
        {
            var id = _context.Acesso
                .Where(u => u.Login == login.Login && u.Password == login.Password)
                .SingleOrDefault();

            var user = _context.Acesso.Find(id.Id);

            if (user == null)
            {
                return NotFound(new { message = "Usuário ou senha não encontrado" });
            }

            var token = TokenService.GenerateToken(user);
            user.Password = "";
            return new
            {
                user = user,
                token = token
            };
        }
    }
}
