using Microsoft.EntityFrameworkCore;

namespace NAKHLA.Models
{
    //[PrimaryKey(nameof(ProductId), nameof(Color))]
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string HexCode { get; set; } 
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}