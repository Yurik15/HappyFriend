using HF.Domain.Models;
using HF.Infrastracture.SeedOfWork;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace HF.Infrastructure.Domain
{
    public class UsersRoleEntityTypeConfiguration
        : DomainEntityTypeConfiguration<UsersRole>
    {
        protected override void Configure(EntityTypeBuilder<UsersRole> builder)
        {
            builder
                 .HasOne(e => e.Users);
        }

    }
}
