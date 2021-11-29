
using MediatR;

namespace HFS.Domain.SeedOfWork
{
    public abstract class DomainEvent : INotification
    {
        public DomainEvent()
        {
        }
    }
}
