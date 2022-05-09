using Microsoft.EntityFrameworkCore;

namespace Locadora.API.Model
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Diretor> Diretores { get; set; }
        public DbSet<Filme> Filmes { get; set; }
    }
}
