using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Features.Shared
{
    public partial class AlterarSenha
    {
        public class Command
        {
            public int id { get; set; }

            public string password { get; set; }

        }
    }
}
