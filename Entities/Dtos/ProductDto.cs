using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record ProductDto
    {
        public int ProductId { get; init; }
        
        [Required(ErrorMessage = "Product name is required.")]
        public String? ProductName { get; init; } = String.Empty;
        [Required(ErrorMessage = "Explnation is required.")]
        public String? Explanation { get; init; } = String.Empty;
        [Required(ErrorMessage = "Price is required.")]
        public int Price { get; init; }
        public int Piece { get; init; }
        [Required(ErrorMessage ="Origin is required.")]
        public String? Origin { get; init; } = String.Empty;
        public String? ImageUrl { get; set; }
        public int? CategoryId { get; init; }
    }
}