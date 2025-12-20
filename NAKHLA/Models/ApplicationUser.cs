using System.ComponentModel.DataAnnotations;

namespace NAKHLA.Models
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? State { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? ZipCode { get; set; }
    }
}
