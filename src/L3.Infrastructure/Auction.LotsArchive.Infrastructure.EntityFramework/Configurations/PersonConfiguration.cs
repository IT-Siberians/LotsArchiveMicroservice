using Auction.Common.Domain.ValueObjects.String;
using Auction.LotsArchiveMicroservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auction.LotsArchiveMicroservice.Infrastructure.EntityFramework.Configurations;

internal class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.IsDeletedSoftly).IsRequired();

        builder.OwnsOne(
            e => e.Username,
            a => a.Property(u => u.Value)
                .HasColumnName("Username")
                .HasMaxLength(Username.MaxLength)
            .IsRequired());

        builder.HasOne(p => p.BuyerInfo)
            .WithOne(b => b.PersonInfo)
            .HasForeignKey<Buyer>(p => p.Id);
        builder.HasOne(p => p.SellerInfo)
            .WithOne(b => b.PersonInfo)
            .HasForeignKey<Seller>(p => p.Id);
    }
}
