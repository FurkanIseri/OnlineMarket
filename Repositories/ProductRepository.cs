using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.Extensions;

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

        public IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameter p)
        {
            return _context
            .Products
            .FilteredByCategoryId(p.CategoryId)
            .FilteredBySearchTerm(p.SearchTerm)
            .FilteredByPrice(p.MaxPrice,p.MinPrice,p.IsValidPrice)
            .ToPaginate(p.PageNumber,p.PageSize);
        }

        public Product? GetOneProduct(int id, bool trackchanges)
        {
            return FindByCondition(p => p.ProductId.Equals(id),trackchanges)
            .Include(p =>p.Category)
            .SingleOrDefault();
        }

        public IQueryable<Product> GetShowcaseProducts(bool trackchanges)
        {
            return FindAll(trackchanges).Where(p => p.ShowCase == true);
        }

        public void UpdateOneProduct(Product product) => Update(product);
    }
}