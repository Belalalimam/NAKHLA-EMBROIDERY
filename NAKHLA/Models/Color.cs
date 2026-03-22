using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NAKHLA.Models
{
    //[PrimaryKey(nameof(ProductId), nameof(Color))]
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HexCode { get; set; }
        [MaxLength(500)]
        [DisplayName("Description")]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}