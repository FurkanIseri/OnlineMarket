using Microsoft.EntityFrameworkCore;
using OnlineMarket.Entities;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _manager;

        public CategoryManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public void CreateOneCategory(Category category)
        {
            _manager.Category.CreateOneCategory(category);
            _manager.Save();
        }

        public void DeleteOneCategory(int id)
        {
            Category categories = _manager.Category.GetOneCategory(id,true).Include(c =>c.CategoryId)
            .SingleOrDefault();
            if(categories is not null)
            {
                _manager.Category.DeleteOneCategory(categories);
                _manager.Save();
            }
        }

        public IQueryable<Category> GetAllCategories(bool trackchanges)
        {
            return _manager.Category.FindAll(trackchanges);
        }

        public Category? GetOneCategory(int id, bool trackchanges)
        {
            return _manager.Category.FindByCondition(c => c.CategoryId.Equals(id),trackchanges)
            .Include(c =>c.CategoryId)
            .SingleOrDefault();
        }

        public void UpdateOneCategory(Category category)
        {
            _manager.Category.UpdateOneCategory(category);
            _manager.Save();
        }
    }
}