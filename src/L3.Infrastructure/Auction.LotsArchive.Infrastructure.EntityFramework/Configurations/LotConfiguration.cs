using Auction.Common.Domain.ValueObjects.Abstract;
using Auction.Common.Domain.ValueObjects.Numeric;
using Auction.Common.Domain.ValueObjects.String;
using Auction.LotsArchiveMicroservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auction.LotsArchiveMicroservice.Infrastructure.EntityFramework.Configurations;

internal class LotConfiguration : IEntityTypeConfiguration<Lot>
{
    public void Configure(EntityTypeBuilder<Lot> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.StartDateTime).IsRequired();
        builder.Property(e => e.EndDateTime).IsRequired();
        builder.Property(e => e.IsUnpurchased).IsRequired();

        builder.OwnsOne(
            e => e.Title,
            a => a.Property(t => t.Value)
                .HasColumnName("Title")
                .HasMaxLength(Title.MaxLength)
                .IsRequired());
        builder.OwnsOne(
            e => e.Description,
            a => a.Property(t => t.Value)
                .HasColumnName("Description")
                .IsRequired());

        builder.OwnsOne(
            e => e.StartingPrice,
            a => a.Property(p => p.Value)
                .HasColumnName("StartingPrice")
                .HasColumnType("money")
                .IsRequired());
        builder.OwnsOne(
            e => e.BidIncrement,
            a => a.Property(p => p.Value)
                .HasColumnName("BidIncrement")
                .HasColumnType("money")
                .IsRequired());

        builder.Property(e => e.RepurchasePrice)
            .HasConversion(price => ToNullable(price), value => value == null ? null : new Price(value.Value))
            .HasColumnType("money")
            .IsRequired(false);

        builder.HasOne(e => e.RepurchasedLot)
            .WithOne(rl => rl.Lot)
            .HasForeignKey<Lot>("_repurchasedLotId")
            .IsRequired(false);
        builder.HasOne(e => e.WithdrawnLot)
            .WithOne(wl => wl.Lot)
            .HasForeignKey<Lot>("_withdrawnLotId")
            .IsRequired(false);

        builder.Property("_repurchasedLotId")
            .HasColumnName("RepurchasedLotId")
            .IsRequired(false);
        builder.Property("_withdrawnLotId")
            .HasColumnName("WithdrawnLotId")
            .IsRequired(false);

        builder.HasOne(e => e.Seller).WithMany("_allLots");
    }

    private static T? ToNullable<T>(ValueObject<T>? valueObject) where T : struct
    {
        if (valueObject is null)
        {
            return null;
        }

        return valueObject.Value;
    }
}