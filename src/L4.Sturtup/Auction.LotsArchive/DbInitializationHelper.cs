using Auction.Common.Domain.ValueObjects.Numeric;
using Auction.Common.Domain.ValueObjects.String;
using Auction.LotsArchive.Domain.Entities;
using Auction.LotsArchive.Infrastructure.EntityFramework;

namespace Auction.LotsArchive;

public static class DbInitializationHelper
{
    public static async Task<Person> CreatePersonAsync(
        this ApplicationDbContext dbContext,
        string username,
        string guid)
    {
        var person = new Person(new Guid(guid), new Username(username));

        await dbContext.Persons.AddAsync(person);

        return person;
    }

    public static async Task<Lot> CreateLotAsync(
        this ApplicationDbContext dbContext,
        string guid,
        string title,
        string description,
        Person sellerPerson,
        decimal startingPrice,
        decimal bidIncrement,
        decimal? repurchasePrice,
        DateTime startDateTime,
        DateTime endDateTime)
    {
        var lot = new Lot(
            new Guid(guid),
            new Title(title),
            new Text(description),
            sellerPerson.SellerInfo,
            new Price(startingPrice),
            new Price(bidIncrement),
            repurchasePrice is null ? null : new Price(repurchasePrice.Value),
            startDateTime,
            endDateTime,
            repurchasedLot: null,
            withdrawnLot: null);

        await dbContext.Lots.AddAsync(lot);

        return lot;
    }

    public static async Task<RepurchasedLot> CreateRepurchasedLotAsync(
        this ApplicationDbContext dbContext,
        string guid,
        DateTime dateTime,
        Person buyerPerson,
        decimal hammerPrice,
        Lot lot)
    {
        var repurchasedLot = new RepurchasedLot(
        new Guid(guid),
        dateTime,
        lot,
            buyerPerson.BuyerInfo,
            new Price(hammerPrice));

        lot.SetRepurchasedLot(repurchasedLot);

        await dbContext.RepurchasedLots.AddAsync(repurchasedLot);

        return repurchasedLot;
    }

    public static async Task<WithdrawnLot> CreateWithdrawnLotAsync(
        this ApplicationDbContext dbContext,
        string guid,
        DateTime dateTime,
        Lot lot)
    {
        var withdrawnLot = new WithdrawnLot(
            new Guid(guid),
            dateTime,
            lot);

        lot.SetWithdrawnLot(withdrawnLot);

        await dbContext.WithdrawnLots.AddAsync(withdrawnLot);

        return withdrawnLot;
    }
}
