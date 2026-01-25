namespace NAKHLA.Models
{
    public class ProjectCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; }
        public string? Icon { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
