using API.Common;
using API.Infrastructure;
using API.Models;
using System;

namespace API.Features.Administradores
{
    public partial class AdicionarUsuario
    {
        public class CommandHandler
        {
            private readonly Context _context;

            public CommandHandler(Context context)
            {
                _context = context;
            }

            public Resolved<Exception> Handle(Command command)
            {
                var novoUsuario = new Acesso
                {
                    Nome = command.nome,
                    Email = command.email,
                    Login = command.login,
                    Password = command.password,
                    Role = command.role,
                };

                _context.Acesso.Add(novoUsuario);
                _context.SaveChanges();

                return Resolved.Ok();
            }
        }
    }
}
