using Auction.LotsArchiveMicroservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auction.LotsArchiveMicroservice.Infrastructure.EntityFramework;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options)
{
    public DbSet<Buyer> Buyers { get; set; }
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<Lot> Lots { get; set; }
    public DbSet<RepurchasedLot> RepurchasedLots { get; set; }
    public DbSet<WithdrawnLot> WithdrawnLots { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
