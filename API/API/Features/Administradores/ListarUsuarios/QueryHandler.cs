using API.Infrastructure;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Features.Administradores
{
    public partial class ListarUsuarios
    {
        public class QueryHandler
        {
            private readonly Context _context;

            public QueryHandler(Context context)
            {
                _context = context;
            }

            public List<Acesso> Handle(Query query)
            {
                var usuarios = _context.Acesso
                    .ToList();

                return usuarios;
            }
        }
    }
}
