using System.Collections.Generic;

namespace HFS.Domain.SeedOfWork
{
    /// <summary>
    /// represents base entity with default id property
    /// </summary>
    public abstract class BaseEntity
    {
        private List<DomainEvent>? _domainEvents;

        public virtual int Id { get; protected set; }

        public IReadOnlyCollection<DomainEvent>? DomainEvents =>
            _domainEvents?.AsReadOnly();


        public void AddDomainEvent(DomainEvent eventItem)
        {
            _domainEvents ??= new List<DomainEvent>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(DomainEvent eventItem) =>
            _domainEvents?.Remove(eventItem);

        public void ClearDomainEvents() =>
            _domainEvents?.Clear();
    }
}
