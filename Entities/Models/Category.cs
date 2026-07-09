using System.ComponentModel.DataAnnotations;

namespace OnlineMarket.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Category name is required.")]
        public String? CategoryName { get; set; } = String.Empty;
        public ICollection<Product>? Products { get; set; }
    }
}