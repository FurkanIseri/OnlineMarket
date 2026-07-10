using Entities.Models;

namespace Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts(bool trackchanges);
        Product? GetOneProduct(int id,bool trackchanges);
        IEnumerable<Product> GetShowcaseProducts(bool trackchanges);
        void CreateOneProduct(Product product);
        void UpdateOneProduct(Product product);
        void DeleteOneProduct(int id);
    }
}