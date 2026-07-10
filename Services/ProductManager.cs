using System.Data.Common;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _manager;

        public ProductManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public void CreateOneProduct(Product product)
        {
            _manager.Product.Create(product);
            _manager.Save();
        }

        public void DeleteOneProduct(int id)
        {
            Product? product = GetOneProduct(id,true);
            if(product is not null)
            {
                _manager.Product.DeleteOneProduct(product);
                _manager.Save();
            }
        }

        public IEnumerable<Product> GetAllProducts(bool trackchanges)
        {
            return _manager.Product.GetAllProducts(trackchanges);
        }

        public Product? GetOneProduct(int id,bool trackchanges)
        {
            var product = _manager.Product.GetOneProduct(id,trackchanges);
            if (product is null)
            {
                throw new Exception("Ürün Bulunumadı");
            }
            return product;
        }

        public IEnumerable<Product> GetShowcaseProducts(bool trackchanges)
        {
            return _manager.Product.GetShowcaseProducts(trackchanges);
        }

        public void UpdateOneProduct(Product product)
        {
            _manager.Product.UpdateOneProduct(product);
            _manager.Save();
        }
    }
}