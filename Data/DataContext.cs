using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
    }
}