using System;

using HFS.Domain.SeedOfWork;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HF.Infrastracture.SeedOfWork
{
    public abstract class DomainEntityTypeConfiguration<TDomainEntity>
        : IEntityTypeConfiguration<TDomainEntity>
        where TDomainEntity : BaseEntity
    {
        void IEntityTypeConfiguration<TDomainEntity>.Configure(
            EntityTypeBuilder<TDomainEntity> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            Configure(builder);
        }

        protected abstract void Configure(EntityTypeBuilder<TDomainEntity> builder);
    }
}
