using Application.Specifications;
using Domain.Common;

namespace Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : BaseDomainModel
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        // Specification pattern
        Task<T> GetByIdWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> GetAllWithSpec(ISpecification<T> spec);
        Task<int> CountAsync(ISpecification<T> spec);
        // Unit of work
        void AddEntity(T entity);
        void UpdateEntity(T entity);
    }
}
