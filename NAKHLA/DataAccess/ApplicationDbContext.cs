using Microsoft.EntityFrameworkCore;

namespace NAKHLA.DataAccess
{
    public class ApplicationDbContext : DbContext 
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) 
        { 
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categorise { get; set; }
        public DbSet<Brand> Brands { get; set; }
        
}
}
