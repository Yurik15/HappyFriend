using Ardalis.Specification;
using HFS.Domain.SeedOfWork;
using HFS.Infrastracture.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HF.Infrastracture.DataAccess
{
    /// <summary>
    /// represents base generic repository with default ef core db methods
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly HfDbContext _dbContext;

        public IUnitOfWork UnitOfWork => _dbContext;

        public BaseRepository(HfDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id).ConfigureAwait(false);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync().ConfigureAwait(false);
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            var specificationResult = await ApplySpecification(spec)
                .ConfigureAwait(false);
            return await specificationResult.ToListAsync().ConfigureAwait(false);
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            var specificationResult = await ApplySpecification(spec)
                .ConfigureAwait(false);
            return await specificationResult.CountAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity)
                .ConfigureAwait(false);

            return entity;
        }

        public Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<T> FirstAsync(ISpecification<T> spec)
        {
            var specificationResult = await ApplySpecification(spec)
                .ConfigureAwait(false);
            return await specificationResult.FirstAsync();
        }

        public async Task<T> FirstOrDefaultAsync(ISpecification<T> spec)
        {
            var specificationResult = await ApplySpecification(spec)
                .ConfigureAwait(false);
            return await specificationResult.FirstOrDefaultAsync();
        }

        private async Task<IQueryable<T>> ApplySpecification(ISpecification<T> spec)
        {
            return await EfSpecificationEvaluator<T>
                .GetQuery(_dbContext.Set<T>().AsQueryable(), spec)
                .ConfigureAwait(false);
        }
    }
}
