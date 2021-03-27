using Microsoft.EntityFrameworkCore;
using O.Entities.Entities;

namespace O.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<OrderForm> Orders { get; set; }
        public DbSet<OrderServices> OrderServices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
