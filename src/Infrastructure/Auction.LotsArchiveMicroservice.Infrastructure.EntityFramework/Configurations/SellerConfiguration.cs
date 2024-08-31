using Auction.Common.Domain.ValueObjects.String;
using Auction.LotsArchiveMicroservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auction.LotsArchiveMicroservice.Infrastructure.EntityFramework.Configurations;

public class SellerConfiguration : IEntityTypeConfiguration<Seller>
{
    public void Configure(EntityTypeBuilder<Seller> builder)
    {
        builder.Property(s => s.Username)
            .IsRequired()
            .HasMaxLength(PersonName.MaxLength)
            .HasConversion(
                name => name.Value,
                str => new PersonName(str)
            );

        builder.HasMany<RepurchasedLot>("_soldLots").WithOne(t => t.Lot.Seller);
        builder.HasMany<WithdrawnLot>("_withdrawnLots").WithOne(t => t.Lot.Seller);
        builder.HasMany<Lot>("_unpurchasedLots").WithOne(t => t.Seller);
    }
}