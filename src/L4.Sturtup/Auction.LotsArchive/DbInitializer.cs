using Auction.Common.Presentation.Initialization;
using Auction.LotsArchive.Infrastructure.EntityFramework;

namespace Auction.LotsArchive;

public class DbInitializer(ApplicationDbContext dbContext) : IDbInitializer
{
    private readonly ApplicationDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    private bool _isDisposed;

    public void Dispose()
    {
        if (!_isDisposed)
        {
            _dbContext.Dispose();

            _isDisposed = true;
        }

        GC.SuppressFinalize(this);
    }

    public async Task InitDatabaseAsync()
    {
        const string person1IdString = "11111111-5717-4562-b3fc-111100001111";
        Guid person1Id = new Guid(person1IdString);

        if (_dbContext.Persons.Any(p => p.Id == person1Id))
        {
            return;
        }

        await InitAsync(person1IdString);

        await _dbContext.SaveChangesAsync();
    }

    private async Task InitAsync(string person1IdString)
    {
        var person1 = await _dbContext.CreatePersonAsync("AlexA", person1IdString);
        var person2 = await _dbContext.CreatePersonAsync("BorisB", "11111111-5717-4562-b3fc-111100002222");
        var person3 = await _dbContext.CreatePersonAsync("CarinC", "11111111-5717-4562-b3fc-111100003333");
        var person4 = await _dbContext.CreatePersonAsync("DenisD", "11111111-5717-4562-b3fc-111100004444");

        var unpurchasedLot1 = await _dbContext.CreateLotAsync(
            guid: "22222222-5717-4562-b3fc-222200001111",
            title: "Первый невыкупленный лот",
            description: "Описание лота",
            person1,
            startingPrice: 1000,
            bidIncrement: 100,
            repurchasePrice: null,
            DateTime.UtcNow.Subtract(TimeSpan.FromDays(10)),
            DateTime.UtcNow.Subtract(TimeSpan.FromDays(8)));
        var unpurchasedLot2 = await _dbContext.CreateLotAsync(
            guid: "22222222-5717-4562-b3fc-222200002222",
            title: "Второй невыкупленный лот",
            description: "Описание лота",
            person1,
            startingPrice: 2000,
            bidIncrement: 200,
            repurchasePrice: null,
            DateTime.UtcNow.Subtract(TimeSpan.FromDays(9)),
            DateTime.UtcNow.Subtract(TimeSpan.FromDays(7)));
        var unpurchasedLot3 = await _dbContext.CreateLotAsync(
            guid: "22222222-5717-4562-b3fc-222200003333",
            title: "Третий невыкупленный лот",
            description: "Описание лота",
            person1,
            startingPrice: 3000,
            bidIncrement: 300,
            repurchasePrice: 3_000_000,
            DateTime.UtcNow.Subtract(TimeSpan.FromDays(8)),
            DateTime.UtcNow.Subtract(TimeSpan.FromDays(6)));
        var unpurchasedLot4 = await _dbContext.CreateLotAsync(
            guid: "22222222-5717-4562-b3fc-222200004444",
            title: "Четвёртый невыкупленный лот",
            description: "Описание лота",
            person4,
            startingPrice: 4000,
            bidIncrement: 400,
            repurchasePrice: 4_000_000,
            DateTime.UtcNow.Subtract(TimeSpan.FromDays(7)),
            DateTime.UtcNow.Subtract(TimeSpan.FromDays(5)));

        var withdrawnLot1 = await _dbContext.CreateWithdrawnLotAsync(
            guid: "44444444-5717-4562-b3fc-444400001111",
            dateTime: DateTime.UtcNow.Subtract(TimeSpan.FromDays(5)),
            lot: await _dbContext.CreateLotAsync(
                guid: "22222222-5717-4562-b3fc-222200005555",
                title: "Отменённый лот 1го продавца",
                description: "Описание лота",
                person1,
                startingPrice: 25000,
                bidIncrement: 1000,
                repurchasePrice: null,
                DateTime.UtcNow.Subtract(TimeSpan.FromDays(6)),
                DateTime.UtcNow.Subtract(TimeSpan.FromDays(4))));
        var withdrawnLot2 = await _dbContext.CreateWithdrawnLotAsync(
            guid: "44444444-5717-4562-b3fc-444400002222",
            dateTime: DateTime.UtcNow.Subtract(TimeSpan.FromDays(5)),
            lot: await _dbContext.CreateLotAsync(
                guid: "22222222-5717-4562-b3fc-222200006666",
                title: "Отменённый лот 4го продавца",
                description: "Описание лота",
                person4,
                startingPrice: 1500,
                bidIncrement: 500,
                repurchasePrice: 50_000,
                DateTime.UtcNow.Subtract(TimeSpan.FromDays(6)),
                DateTime.UtcNow.Subtract(TimeSpan.FromDays(4))));

        var repurchasedLot1 = await _dbContext.CreateRepurchasedLotAsync(
            guid: "33333333-5717-4562-b3fc-333300001111",
            dateTime: DateTime.UtcNow.Subtract(TimeSpan.FromDays(5)),
            buyerPerson: person2,
            hammerPrice: 3500,
            lot: await _dbContext.CreateLotAsync(
                guid: "22222222-5717-4562-b3fc-222200007777",
                title: "Первый выкупленный лот первого продавца",
                description: "Описание лота",
                person1,
                startingPrice: 2500,
                bidIncrement: 500,
                repurchasePrice: null,
                DateTime.UtcNow.Subtract(TimeSpan.FromDays(7)),
                DateTime.UtcNow.Subtract(TimeSpan.FromDays(4))));
        var repurchasedLot2 = await _dbContext.CreateRepurchasedLotAsync(
            guid: "33333333-5717-4562-b3fc-333300002222",
            dateTime: DateTime.UtcNow.Subtract(TimeSpan.FromDays(4)),
            buyerPerson: person3,
            hammerPrice: 33000,
            lot: await _dbContext.CreateLotAsync(
                guid: "22222222-5717-4562-b3fc-222200008888",
                title: "Второй выкупленный лот первого продавца",
                description: "Описание лота",
                person1,
                startingPrice: 10000,
                bidIncrement: 1000,
                repurchasePrice: 50_000,
                DateTime.UtcNow.Subtract(TimeSpan.FromDays(8)),
                DateTime.UtcNow.Subtract(TimeSpan.FromDays(3))));
        var repurchasedLot3 = await _dbContext.CreateRepurchasedLotAsync(
            guid: "33333333-5717-4562-b3fc-333300003333",
            dateTime: DateTime.UtcNow.Subtract(TimeSpan.FromDays(3)),
            buyerPerson: person4,
            hammerPrice: 3500,
            lot: await _dbContext.CreateLotAsync(
                guid: "22222222-5717-4562-b3fc-222200009999",
                title: "Выкупленный лот 3го продавца",
                description: "Описание лота",
                person3,
                startingPrice: 2500,
                bidIncrement: 500,
                repurchasePrice: null,
                DateTime.UtcNow.Subtract(TimeSpan.FromDays(5)),
                DateTime.UtcNow.Subtract(TimeSpan.FromDays(1))));
        var repurchasedLot4 = await _dbContext.CreateRepurchasedLotAsync(
            guid: "33333333-5717-4562-b3fc-333300004444",
            dateTime: DateTime.UtcNow.Subtract(TimeSpan.FromDays(2)),
            buyerPerson: person3,
            hammerPrice: 2500,
            lot: await _dbContext.CreateLotAsync(
                guid: "22222222-5717-4562-b3fc-22220000aaaa",
                title: "Выкупленный лот 4го продавца",
                description: "Описание лота",
                person4,
                startingPrice: 2500,
                bidIncrement: 500,
                repurchasePrice: null,
                DateTime.UtcNow.Subtract(TimeSpan.FromDays(5)),
                DateTime.UtcNow.Subtract(TimeSpan.FromDays(1))));
    }
}
