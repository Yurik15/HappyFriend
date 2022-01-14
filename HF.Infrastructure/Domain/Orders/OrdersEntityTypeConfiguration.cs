using HF.Domain.Models;
using HF.Infrastracture.SeedOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace HF.Infrastructure.Domain
{
    public class OrdersEntityTypeConfiguration
        : DomainEntityTypeConfiguration<Order>
    {
        protected override void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasOne(e => e.Users);
        }
    }
}
