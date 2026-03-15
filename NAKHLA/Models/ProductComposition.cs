using Microsoft.EntityFrameworkCore;

namespace NAKHLA.Models
{
    public class ProductComposition
    {
        public int id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int CompositionId { get; set; }
        public Composition Composition { get; set; }

        public decimal Percentage { get; set; } // النسبة المئوية (مثلاً 58.00)

    }
}