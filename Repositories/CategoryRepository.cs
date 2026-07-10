using Entities.Models;
using Microsoft.EntityFrameworkCore;

using Repositories.Contracts;

namespace Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneCategory(Category category) => Create(category);

        public void DeleteOneCategory(Category category) => Remove(category);

        public IQueryable<Category> GetAllCategories(bool trackchanges) => FindAll(trackchanges);

        public IQueryable<Category> GetOneCategory(int id, bool trackchanges)
        {
            return FindByCondition(c => c.CategoryId.Equals(id),trackchanges);
        }

        public void UpdateOneCategory(Category category) => Update(category);
    }
}