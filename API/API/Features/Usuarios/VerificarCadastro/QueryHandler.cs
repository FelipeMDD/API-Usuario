using API.Infrastructure;
using API.Models;
using LanguageExt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Features.Usuarios
{
    public partial class VerificarCadastro
    {
        public class QueryHandler
        {
            private readonly Context _context;

            public QueryHandler(Context context)
            {
                _context = context;
            }

            public Option<Acesso> Handle(Query query)
            {
                Option<Acesso> usuario = _context.Acesso
                    .Where(u => u.Id == query.id)
                    .AsNoTracking()
                    .SingleOrDefault();

                return usuario;
            }
        }
    }
}
