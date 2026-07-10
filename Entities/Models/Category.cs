using System.ComponentModel.DataAnnotations;
using Entities.Models;

namespace Entities.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Category name is required.")]
        public String? CategoryName { get; set; } = String.Empty;
        public ICollection<Product>? Products { get; set; }
    }
}