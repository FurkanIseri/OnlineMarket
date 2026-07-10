using Entities.Models;


namespace Repositories.Contracts
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        public IQueryable<Category> GetAllCategories(bool trackchanges);
        public IQueryable<Category> GetOneCategory(int id,bool trackchanges);
        void CreateOneCategory(Category category);
        void DeleteOneCategory(Category category);
        void UpdateOneCategory(Category category);
    }
}