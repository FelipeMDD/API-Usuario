using API.Common;
using API.Infrastructure;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace API.Features.Login
{
    public partial class GerarToken
    {
        public class CommandHandler
        {
            private readonly Context _context;

            public CommandHandler(Context context)
            {
                _context = context;
            }

            public ActionResult<dynamic> Handle(Command command)
            {
                var id = _context.Acesso
                    .Where(u => u.Login == command.login && u.Password == command.password)
                    .SingleOrDefault();

                var user = _context.Acesso.Find(id.Id);

                if (user == null)
                {
                    return Resolved.Err(
                        new InvalidOperationException("Não é possível alterar a senha")
                    );
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
}
