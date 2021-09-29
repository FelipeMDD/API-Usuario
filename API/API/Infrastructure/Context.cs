using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public virtual DbSet<Acesso> Acesso { get; set; }

    }
}
