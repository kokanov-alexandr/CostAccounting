using Microsoft.EntityFrameworkCore;

namespace CostAccounting.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) { }
        public DbSet<Purchase> Purchases => Set<Purchase>();
        public DbSet<Category> Categories => Set<Category>();
    }
}