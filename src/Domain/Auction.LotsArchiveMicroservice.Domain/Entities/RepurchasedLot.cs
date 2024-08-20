using Auction.Common.Domain.Entities;
using Auction.Common.Domain.Exceptions;
using Auction.Common.Domain.ValueObjects;
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
    /// Конечная цена выкупа лота
    /// </summary>
    public Money EndPrice { get; }

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
        Money endPrice)
    {
        Lot = lot ?? throw new ArgumentNullValueException(nameof(lot));
        Buyer = buyer ?? throw new ArgumentNullValueException(nameof(buyer));
        EndPrice = endPrice ?? throw new ArgumentNullValueException(nameof(endPrice));

        Id = id;
        Date = date;
    }
}
