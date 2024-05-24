using ApiSysSchoolar.Models;

namespace ApiSysSchoolar.Repositories.Application;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllASync();
    Task<T> GetByIdAsync(int id);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task<int> DeleteAsync(int id);
}

