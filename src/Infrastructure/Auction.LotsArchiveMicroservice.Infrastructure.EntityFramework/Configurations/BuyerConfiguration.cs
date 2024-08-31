using Auction.Common.Domain.ValueObjects.String;
using Auction.LotsArchiveMicroservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auction.LotsArchiveMicroservice.Infrastructure.EntityFramework.Configurations;

public class BuyerConfiguration : IEntityTypeConfiguration<Buyer>
{
    public void Configure(EntityTypeBuilder<Buyer> builder)
    {
        builder.Property(b => b.Username)
            .IsRequired()
            .HasMaxLength(PersonName.MaxLength)
            .HasConversion(
                name => name.Value,
                str => new PersonName(str)
            );

        builder.HasMany<RepurchasedLot>("_boughtLots").WithOne(t => t.Buyer);
    }
}
