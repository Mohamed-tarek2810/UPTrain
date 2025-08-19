using System.Linq.Expressions;

namespace UPTrain.IRepositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null ,params Expression<Func<T, object>>[] includes);
       
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<bool> CommitAsync();
    }
}