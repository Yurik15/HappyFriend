using HF.Domain.Models;
using HF.Infrastracture.SeedOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace HF.Infrastructure.Domain
{
    public class UsersFileEntityTypeConfiguration
        : DomainEntityTypeConfiguration<UsersFile>
    {
        protected override void Configure(EntityTypeBuilder<UsersFile> builder)
        {
            builder
                .HasOne(e => e.Users);
        }
    }


}
