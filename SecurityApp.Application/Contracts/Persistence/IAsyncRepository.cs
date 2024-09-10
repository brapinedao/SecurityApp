using SecurityApp.Domain.Common;

namespace SecurityApp.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : BaseDomain
    {
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T> GetByIdAsync(string id);

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}
