using Ardalis.Specification;
using HF.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HF.Infrastructure.Domain
{
    public interface IExampleRepository
    {
        #region Base repo methods

        Task<Example> GetByIdAsync(int id);
        Task<IReadOnlyList<Example>> ListAllAsync();
        Task<IReadOnlyList<Example>> ListAsync(ISpecification<Example> spec);
        Task<int> CountAsync(ISpecification<Example> spec);
        Task<Example> AddAsync(Example entity);
        Task UpdateAsync(Example entity);
        Task DeleteAsync(Example entity);
        Task<Example> FirstAsync(ISpecification<Example> spec);
        Task<Example> FirstOrDefaultAsync(ISpecification<Example> spec);

        #endregion Base repo methods
    }
}
