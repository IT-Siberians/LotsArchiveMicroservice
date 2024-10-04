using Auction.Common.Domain.ValueObjects.Numeric;
using Auction.LotsArchiveMicroservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auction.LotsArchiveMicroservice.Infrastructure.EntityFramework.Configurations;

public class RepurchasedLotConfiguration : IEntityTypeConfiguration<RepurchasedLot>
{
    public void Configure(EntityTypeBuilder<RepurchasedLot> builder)
    {
        builder.Property(e => e.HammerPrice)
            .HasConversion(
                price => price.Value,
                number => new Price(number)
            );

        builder.HasOne(t => t.Lot).WithOne();
        builder.HasOne(t => t.Buyer).WithMany("_boughtLots");
    }
}
