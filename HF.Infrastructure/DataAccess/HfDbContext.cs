
using MediatR;

using Microsoft.EntityFrameworkCore;

using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace HFS.Infrastracture.DataAccess
{
    public class HfDbContext : DbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;
        public HfDbContext(DbContextOptions<HfDbContext> options, IMediator mediator)
            : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // entities configuration
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly());
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEventsAsync(this)
                .ConfigureAwait(false);


            return await SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        async ValueTask IAsyncDisposable.DisposeAsync() => await DisposeAsync();
    }
}
