using Entities.Models;

namespace OnlineMarketApp.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; } = Enumerable.Empty<Product>();
        public Pagination Pagination { get; set; }
        public int TotalCount => Products.Count();
    }
}