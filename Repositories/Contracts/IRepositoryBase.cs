using System.Linq.Expressions;

namespace Repositories.Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool trackchanges); // Tüm sonuçları getirme
        IQueryable<T> FindByCondition(Expression<Func<T,bool>> expression,bool trackchanges);
        void Create(T entity);
        void Remove(T entity);
        void Update(T entity);

    }
}