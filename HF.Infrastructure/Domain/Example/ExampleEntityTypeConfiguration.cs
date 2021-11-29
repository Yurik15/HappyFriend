using HF.Domain.Models;
using HF.Infrastracture.SeedOfWork;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HF.Infrastructure.Domain
{
    public class ExampleEntityTypeConfigurationW
        : DomainEntityTypeConfiguration<Example>
    {
        protected override void Configure(EntityTypeBuilder<Example> builder)
        {
            //builder
            //    .ToTable("Example");

            builder
                .HasKey(e => e.Id);
        }
    }
}
