using Microsoft.EntityFrameworkCore;
using NoteSandbax.Models;

namespace NoteSandbax.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Notes> Notes { get; set; }

    }
}
