using System.Linq;
using System.Threading.Tasks;

using HFS.Domain.SeedOfWork;

using MediatR;

namespace HFS.Infrastracture.DataAccess
{
    internal static class MediatorExtensions
    {
        public static async Task DispatchDomainEventsAsync(
            this IMediator mediator,
            HfDbContext ctx)
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<BaseEntity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities
                .ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            foreach (var domainEvent in domainEvents)
            {
                await mediator.Publish(domainEvent)
                    .ConfigureAwait(false);
            }
        }
    }
}
