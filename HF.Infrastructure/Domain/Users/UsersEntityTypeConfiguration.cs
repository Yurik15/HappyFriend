using HF.Domain.Models;
using HF.Infrastracture.SeedOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HF.Infrastructure.Domain
{
    public class UsersEntityTypeConfiguration
        : DomainEntityTypeConfiguration<Users>
    {
        protected override void Configure(EntityTypeBuilder<Users> builder)
        {
            builder
                .HasMany(e => e.UserFiles)
                .WithOne(e => e.Users)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasMany(e => e.UserRoles)
                .WithOne(e => e.Users)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
