using OnlineMarket.Entities;

namespace Services.Contracts
{
    public interface ICategoryService
    {
        public IQueryable<Category> GetAllCategories(bool trackchanges);
        public Category? GetOneCategory(int id,bool trackchanges);
        void CreateOneCategory(Category category);
        void DeleteOneCategory(int id);
        void UpdateOneCategory(Category category);
    }
}