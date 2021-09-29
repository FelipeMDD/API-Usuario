using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Features.Administradores
{
    public partial class AdicionarUsuario
    {
        public class Command
        {
            public string login { get; set; }

            public string password { get; set; }

            public string role { get; set; }

            public string nome { get; set; }

            public string email { get; set; }
        }
    }
}
