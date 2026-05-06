using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Product
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 5)]
        public string ProductName { get; set; }

        [StringLength(15, MinimumLength = 5)]
        public string Category { get; set; }

        [Required]
        public decimal Price { get; set; }

    }
}