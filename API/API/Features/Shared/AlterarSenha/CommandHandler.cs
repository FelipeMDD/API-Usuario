using API.Common;
using API.Infrastructure;
using API.Models;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Features.Shared
{
    public partial class AlterarSenha
    {
        public class CommandHandler
        {
            private readonly Context _context;

            public CommandHandler(Context context)
            {
                _context = context;
            }

            public Resolved<InvalidOperationException> Handle(Command command)
            {
                Option<Acesso> aluno = _context.Acesso
                    .Where(a => command.id == a.Id)
                    .SingleOrDefault();

                var resolved = aluno.Match<Resolved<InvalidOperationException>>(
                    Some: a =>
                    {
                        a.Password = command.password;
                        return Resolved.Ok();
                    },
                    None: () => Resolved.Err(
                        new InvalidOperationException("Não é possível alterar a senha")
                    )
                );

                _context.SaveChanges();

                return resolved;
            }
        }
    }
}
