using Auction.Common.Domain.ValueObjects;
using Auction.LotsArchiveMicroservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auction.LotsArchiveMicroservice.Infrastructure.EntityFramework.Configurations;

public class BuyerConfiguration : IEntityTypeConfiguration<Buyer>
{
    public void Configure(EntityTypeBuilder<Buyer> builder)
    {
        builder.Property<Name>("_username")
            .IsRequired()
            .HasMaxLength(Name.MaxLength)
            .HasConversion(
                name => name.Value,
                str => new Name(str)
            );

        builder.HasMany<RepurchasedLot>("_boughtLots").WithOne(t => t.Buyer);
    }
}
