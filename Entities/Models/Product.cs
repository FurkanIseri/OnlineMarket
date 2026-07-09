namespace OnlineMarket.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public String? ProductName { get; set; } = String.Empty;
        public String? Explanation { get; set; } = String.Empty;
        public int Price { get; set; }
        public int Piece { get; set; }
        public String? Origin { get; set; } = String.Empty;
        public bool ShowCase { get; set; }
        public Category? Category { get; set; }
    }
}