using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace NAKHLA.DataAccess
{
    public class ApplicationDbContext : DbContext 
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }  

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSubImage> ProductSubImages { get; set; }
        public DbSet<Category> Categorise { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<UserOTP> UserOTPs { get; set; }
        public DbSet<Cart> Carts { get; set; } = default!;
    }
}
