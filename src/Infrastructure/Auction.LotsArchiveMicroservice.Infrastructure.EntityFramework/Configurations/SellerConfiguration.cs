using Auction.LotsArchiveMicroservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auction.LotsArchiveMicroservice.Infrastructure.EntityFramework.Configurations;

internal class SellerConfiguration : IEntityTypeConfiguration<Seller>
{
    public void Configure(EntityTypeBuilder<Seller> builder)
    {
        builder.Ignore(e => e.AllLots);
        builder.Ignore(e => e.WithdrawnLots);
        builder.Ignore(e => e.UnpurchasedLots);
        builder.Ignore(e => e.SoldLots);

        builder.HasMany<Lot>("_allLots").WithOne(t => t.Seller);

        builder.ToTable("Persons");
    }
}