using Auction.LotsArchive.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auction.LotsArchive.Infrastructure.EntityFramework.Configurations;

internal class BuyerConfiguration : IEntityTypeConfiguration<Buyer>
{
    public void Configure(EntityTypeBuilder<Buyer> builder)
    {
        builder.Ignore(e => e.BoughtLots);

        builder.HasMany<RepurchasedLot>("_boughtLots").WithOne(t => t.Buyer);

        builder.ToTable("Persons");
    }
}
