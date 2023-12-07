using MaterialsExchange.Models;
using Microsoft.EntityFrameworkCore;

namespace MaterialsExchange.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Material> Material {  get; set; }
        public DbSet<Seller> Seller { get; set; }
    }
}
