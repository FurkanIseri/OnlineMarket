using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;

namespace Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts(bool trackchanges);
        IEnumerable<Product> GetLastestProducts(int n,bool trackchanges);
        IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameter p);
        Product? GetOneProduct(int id,bool trackchanges);
        IEnumerable<Product> GetShowcaseProducts(bool trackchanges);
        void CreateOneProduct(ProductDtoForInsertion product);
        void UpdateOneProduct(ProductDtoForUpdate product);
        void DeleteOneProduct(int id);
        ProductDtoForUpdate GetOneProductForUpdate(int id,bool trackchanges);
    }
}