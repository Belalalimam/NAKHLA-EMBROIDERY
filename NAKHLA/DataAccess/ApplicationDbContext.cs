//using NAKHLA.DataAccess.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace NAKHLA.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser >
    {
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }  

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductSubImages { get; set; }
        public DbSet<Category> Categorise { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<UserOTP> UserOTPs { get; set; }
        public DbSet<Cart> Carts { get; set; } = default!;
        public DbSet<ProductAttribute> productAttributes { get; set; }
        public DbSet<ProductTag> productTags { get; set; }
        public DbSet<ProductReview> productReviews  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ProductColor>()
            //    .HasKey(e => new { e.ProductId, e.Color });

            //modelBuilder.Entity<ProductSubImage>()
            //    .HasKey(e => new { e.ProductId, e.Img });

            //new ProductColorEntityTypeConfiguration().Configure(modelBuilder.Entity<ProductColor>());
            //new ProductImgEntityTypeConfiguration().Configure(modelBuilder.Entity<ProductSubImage>());

            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductColorEntityTypeConfiguration).Assembly);

            base.OnModelCreating(modelBuilder);
        }



    }



    
}
