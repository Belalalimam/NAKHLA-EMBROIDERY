using System.ComponentModel.DataAnnotations;

namespace NAKHLA.Models
{
    public class Brand
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Brand Name")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [MaxLength(500)]
        public string Description { get; set; }

        [Display(Name = "Website")]
        [Url]
        public string Website { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; } = "Active"; // Active, Inactive

        [Display(Name = "Is Featured")]
        public bool IsFeatured { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Display(Name = "Updated Date")]
        public DateTime? UpdatedDate { get; set; }


        public List<Product> Products { get; set; }



    }
}
