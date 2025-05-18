using CarMk.Core.Response;

namespace CarMk.Core.Shared.Repositories.Generics;

public interface IRepositoryBase<T> where T : class
{
    Task<T> Create(T entity);
    Task<PagedResponse<T>> GetAll(int pageNumber, int pageSize);
    Task<T> GetById(string id);
    Task<T> Update(T entity);
}
