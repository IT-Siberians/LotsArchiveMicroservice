using Auction.LotsArchiveMicroservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auction.LotsArchiveMicroservice.Infrastructure.EntityFramework.Configurations;

internal class RepurchasedLotConfiguration : IEntityTypeConfiguration<RepurchasedLot>
{
    public void Configure(EntityTypeBuilder<RepurchasedLot> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.DateTime).IsRequired();

        builder.OwnsOne(
            e => e.HammerPrice,
            a => a.Property(p => p.Value)
                .HasColumnName("HammerPrice")
                .HasColumnType("money")
                .IsRequired());

        builder.HasOne(rl => rl.Lot)
            .WithOne(e => e.RepurchasedLot)
            .HasForeignKey<RepurchasedLot>("_lotId")
            .IsRequired();

        builder.Property("_lotId")
            .HasColumnName("LotId")
            .IsRequired();

        builder.HasOne(rl => rl.Buyer)
            .WithMany("_boughtLots");
    }
}
