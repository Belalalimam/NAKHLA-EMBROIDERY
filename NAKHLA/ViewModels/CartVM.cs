namespace NAKHLA.ViewModels
{
    public class CartVM
    {
        public List<Cart> CartItems { get; set; } = new();

        // Totals
        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Shipping { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }

        // Promotion
        public string? PromotionCode { get; set; }
        public string? PromotionName { get; set; }

        // Suggested products
        public List<Product> SuggestedProducts { get; set; } = new();
    }
}
