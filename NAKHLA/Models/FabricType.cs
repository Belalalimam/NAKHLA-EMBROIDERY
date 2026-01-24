namespace NAKHLA.Models
{
    public class FabricType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
