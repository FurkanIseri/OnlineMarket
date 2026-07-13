using System.ComponentModel.DataAnnotations;


namespace Entities.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        
        [Required(ErrorMessage = "Product name is required.")]
        public String? ProductName { get; set; } = String.Empty;
        [Required(ErrorMessage = "Explnation is required.")]
        public String? Explanation { get; set; } = String.Empty;
        [Required(ErrorMessage = "Price is required.")]
        public int Price { get; set; }
        public int Piece { get; set; }
        [Required(ErrorMessage ="Origin is required.")]
        public String? Origin { get; set; } = String.Empty;
        public String? ImageUrl {get; set;}
        public bool ShowCase { get; set; } = false;
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}