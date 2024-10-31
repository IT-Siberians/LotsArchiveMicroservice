using Auction.LotsArchive.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auction.LotsArchive.Infrastructure.EntityFramework.Configurations;

internal class WithdrawnLotConfiguration : IEntityTypeConfiguration<WithdrawnLot>
{
    public void Configure(EntityTypeBuilder<WithdrawnLot> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.DateTime).IsRequired();

        builder.HasOne(wl => wl.Lot)
            .WithOne(e => e.WithdrawnLot)
            .HasForeignKey<WithdrawnLot>("_lotId")
            .IsRequired();

        builder.Property("_lotId")
            .HasColumnName("LotId")
            .IsRequired();
    }
}
