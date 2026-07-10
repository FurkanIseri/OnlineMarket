using Entities.Models;


namespace Repositories.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IQueryable<Product> GetAllProducts(bool trackchanges);
        Product? GetOneProduct(int id,bool trackchanges);
        IQueryable<Product> GetShowcaseProducts(bool trackchanges);
        void CreateOneProduct(Product product);
        void DeleteOneProduct(Product product);
        void UpdateOneProduct(Product product);
    }
}