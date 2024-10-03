using HocicosBacks.Models;
using Microsoft.EntityFrameworkCore;

namespace HocicosBack.Context
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Producto> Productos { get; set; }

    }
}
