using Microsoft.EntityFrameworkCore;
using parcial1.Models;

namespace parcial1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Faculties> Faculties { get; set; }
    }
}

