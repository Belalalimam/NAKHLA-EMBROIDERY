using Microsoft.EntityFrameworkCore;

namespace NAKHLA.Models
{
    //[PrimaryKey(nameof(ProductId), nameof(Color))]
    public class ProductColor
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; } = null!;
        public string? Name { get; set; }
        public string Color { get; set; } = string.Empty;
    }
}