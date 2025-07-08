using System.Linq.Expressions;

namespace RFP_APP.Server.Repositories.Interfaces
{
  public interface IBaseRepository<T> where T : class
    {
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task DeleteAsync(T entity);
    Task UpdateAsync(T entity);
    Task SaveChangesAsync();
    IQueryable<T> Query();
    }  
}
