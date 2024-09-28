using Auction.Common.Domain.Entities;
using Auction.Common.Domain.EntitiesExceptions;
using Auction.Common.Domain.ValueObjects.Numeric;
using System;

namespace Auction.LotsArchiveMicroservice.Domain.Entities;

/// <summary>
/// Информация о выкупе лота
/// </summary>
public class RepurchasedLot : IEntity<Guid>
{
    /// <summary>
    /// Уникальный идентификатор записи о выкупе лота
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Дата выкупа лота
    /// </summary>
    public DateTime Date { get; }

    /// <summary>
    /// Выкупленный лот
    /// </summary>
    public Lot Lot { get; }

    /// <summary>
    /// Покупатель лота
    /// </summary>
    public Buyer Buyer { get; }

    /// <summary>
    /// Цена за которую лот был выкуплен
    /// </summary>
    public Price HammerPrice { get; }

    /// <summary>
    /// Конструктор для EF
    /// </summary>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected RepurchasedLot() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    /// <summary>
    /// Основной конструктор информации о выкупе лота
    /// </summary>
    /// <param name="id">Уникальный идентификатор записи о выкупе лота</param>
    /// <param name="date">Дата выкупа лота</param>
    /// <param name="lot">Выкупленный лот</param>
    /// <param name="buyer">Покупатель лота</param>
    /// <param name="endPrice">Конечная цена выкупа лота</param>
    /// <exception cref="ArgumentNullValueException">Если аргумент null</exception>
    public RepurchasedLot(
        Guid id,
        DateTime date,
        Lot lot,
        Buyer buyer,
        Price endPrice)
    {
        Id = GuidEmptyValueException.GetGuidOrThrowIfEmpty(id);

        Lot = lot ?? throw new ArgumentNullValueException(nameof(lot));
        Buyer = buyer ?? throw new ArgumentNullValueException(nameof(buyer));
        HammerPrice = endPrice ?? throw new ArgumentNullValueException(nameof(endPrice));

        Date = date;
    }
}
