using System.ComponentModel.DataAnnotations;

namespace NAKHLA.ViewModels
{
    public class ProductCompositionVM
    {
        public int CompositionId { get; set; }
        public decimal Percentage { get; set; }
    }
}