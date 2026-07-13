namespace Entities.RequestParameters
{
    public class ProductRequestParameter : RequestParameters
    {
        public int? CategoryId { get; set; }
        public int MinPrice { get; set; } = 0;
        public int MaxPrice { get; set; } = int.MaxValue;
        public bool IsValidPrice => MaxPrice > MinPrice;
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public ProductRequestParameter() : this(1, 6)
        {
            
        }
        public ProductRequestParameter(int pageNumber,int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}