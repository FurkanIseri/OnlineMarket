using Entities.Models;
using Entities.RequestParameters;


namespace Repositories.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IQueryable<Product> GetAllProducts(bool trackchanges);
        IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameter p);
        Product? GetOneProduct(int id,bool trackchanges);
        IQueryable<Product> GetShowcaseProducts(bool trackchanges);
        void CreateOneProduct(Product product);
        void DeleteOneProduct(Product product);
        void UpdateOneProduct(Product product);
    }
}