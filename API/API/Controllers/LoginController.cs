using System.Linq;
using Microsoft.AspNetCore.Mvc;
using API.Infrastructure;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using API.Services;

namespace API.Controllers
{
    [Route("api/[controller]")]
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
            var id = _context.Acesso.Where(u => u.Login == login.Login && u.Password == login.Password).SingleOrDefault();

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