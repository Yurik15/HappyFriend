using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.Specification;
using HFS.Domain.SeedOfWork;

namespace HFS.Infrastracture.DataAccess
{
    public interface IBaseRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }


    /// <summary>
    /// base repository interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseRepository<T> : IBaseRepository
        where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<int> CountAsync(ISpecification<T> spec);
        Task<T> FirstAsync(ISpecification<T> spec);
        Task<T> FirstOrDefaultAsync(ISpecification<T> spec);
    }
}
