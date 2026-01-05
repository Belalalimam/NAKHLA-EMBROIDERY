namespace NAKHLA.Models
{
    public class ProductTag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
