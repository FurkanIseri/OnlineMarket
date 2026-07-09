using Microsoft.EntityFrameworkCore;
using OnlineMarket.Entities;
using Repositories.Contracts;

namespace Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneProduct(Product product) => Create(product);

        public void DeleteOneProduct(Product product) => Remove(product);

        public IQueryable<Product> GetAllProducts(bool trackchanges) => FindAll(trackchanges).Include(p => p.Category);


        public Product? GetOneProduct(int id, bool trackchanges)
        {
            return FindByCondition(p => p.ProductId.Equals(id),trackchanges)
            .Include(p =>p.Category)
            .SingleOrDefault();
        }

        public void UpdateOneProduct(Product product) => Update(product);
    }
}