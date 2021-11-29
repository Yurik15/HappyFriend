using HF.Domain.Models;
using HF.Infrastracture.SeedOfWork;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HF.Infrastructure.Domain
{
    public class UsersEntityTypeConfiguration
        : DomainEntityTypeConfiguration<Users>
    {
        protected override void Configure(EntityTypeBuilder<Users> builder)
        {
            builder
                .HasKey(e => e.Id);
        }
    }
}
