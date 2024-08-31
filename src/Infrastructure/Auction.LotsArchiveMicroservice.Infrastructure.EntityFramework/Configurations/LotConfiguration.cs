using Auction.Common.Domain.ValueObjects.Numeric;
using Auction.Common.Domain.ValueObjects.String;
using Auction.LotsArchiveMicroservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auction.LotsArchiveMicroservice.Infrastructure.EntityFramework.Configurations;

public class LotConfiguration : IEntityTypeConfiguration<Lot>
{
    public void Configure(EntityTypeBuilder<Lot> builder)
    {
        builder.Property(e => e.Title)
            .IsRequired()
            .HasMaxLength(Title.MaxLength)
            .HasConversion(
                name => name.Value,
                str => new Title(str)
            );
        builder.Property(e => e.Description)
            .IsRequired()
            .HasConversion(
                text => text.Value,
                str => new Text(str)
            );
        builder.Property(e => e.StartingPrice)
            .HasConversion(
                price => price.Value,
                number => new Price(number)
            );
        builder.Property(e => e.PriceStep)
            .HasConversion(
                price => price.Value,
                number => new Price(number)
            );

        builder.HasOne(t => t.Seller).WithMany("_unpurchasedLots");
    }
}