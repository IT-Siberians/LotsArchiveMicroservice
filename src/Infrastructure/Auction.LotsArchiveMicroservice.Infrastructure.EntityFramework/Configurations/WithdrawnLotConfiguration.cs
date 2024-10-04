using Auction.LotsArchiveMicroservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auction.LotsArchiveMicroservice.Infrastructure.EntityFramework.Configurations;

public class WithdrawnLotConfiguration : IEntityTypeConfiguration<WithdrawnLot>
{
    public void Configure(EntityTypeBuilder<WithdrawnLot> builder)
    {
        builder.HasOne(t => t.Lot).WithOne();
    }
}
