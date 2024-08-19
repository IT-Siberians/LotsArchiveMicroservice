using Auction.Common.Domain.ValueObjects;
using Auction.LotsArchiveMicroservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auction.LotsArchiveMicroservice.Infrastructure.EntityFramework.Configurations;

public class LotConfiguration : IEntityTypeConfiguration<Lot>
{
    public void Configure(EntityTypeBuilder<Lot> builder)
    {
        builder.Property<Name>("_title")
            .IsRequired()
            .HasMaxLength(Name.MaxLength)
            .HasConversion(
                name => name.Value,
                str => new Name(str)
            );
        builder.Property<Text>("_description")
            .IsRequired()
            .HasConversion(
                text => text.Value,
                str => new Text(str)
            );

        builder.Property(e => e.StartingPrice)
            .HasConversion(
                money => money.Value,
                number => new Money(number)
            );
        builder.Property(e => e.PriceStep)
            .HasConversion(
                money => money.Value,
                number => new Money(number)
            );

        builder.HasOne(t => t.Seller).WithMany("_unpurchasedLots");
    }
}