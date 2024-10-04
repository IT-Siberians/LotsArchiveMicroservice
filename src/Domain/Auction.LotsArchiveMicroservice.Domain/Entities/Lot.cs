using Auction.Common.Domain.Entities;
using Auction.Common.Domain.EntitiesExceptions;
using Auction.Common.Domain.ValueObjects.Numeric;
using Auction.Common.Domain.ValueObjects.String;
using System;

namespace Auction.LotsArchiveMicroservice.Domain.Entities;

/// <summary>
/// Основная информация по лоту
/// </summary>
public class Lot : AbstractLot<Guid>
{
    /// <summary>
    /// Продавец
    /// </summary>
    public Seller Seller { get; }

    /// <summary>
    /// Начальная цена
    /// </summary>
    public Price StartingPrice { get; }

    /// <summary>
    /// Минимальный шаг цены
    /// </summary>
    public Price BidIncrement { get; }

    /// <summary>
    /// Фиксированная ставка выкупа
    /// </summary>
    public Price RepurchasePrice { get; }

    /// <summary>
    /// Дата старта торгов по лоту
    /// </summary>
    public DateTime StartDate { get; }

    /// <summary>
    /// Дата окончания торгов по лоту
    /// </summary>
    public DateTime? EndDate { get; protected set; }

    /// <summary>
    /// Конструктор для EF
    /// </summary>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected Lot() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    /// <summary>
    /// Основной конструктор лота
    /// </summary>
    /// <param name="id">Уникальный идентификатор лота</param>
    /// <param name="title">Название лота</param>
    /// <param name="description">Описание лота</param>
    /// <param name="seller">Продавец лота</param>
    /// <param name="startingPrice">Начальная цена лота</param>
    /// <param name="priceStep">Минимальный шаг цены лота</param>
    /// <param name="startDate">Дата старта торгов по лоту</param>
    /// <param name="endDate">Дата окончания торгов по лоту</param>
    /// <exception cref="ArgumentNullValueException">Если аргумент null</exception>
    public Lot(
        Guid id,
        Title title,
        Text description,
        Seller seller,
        Price startingPrice,
        Price bidIncrement,
        Price repurchasePrice,
        DateTime startDate,
        DateTime? endDate = null)
            : base(id, title, description)
    {
        GuidEmptyValueException.ThrowIfEmpty(id);

        Seller = seller ?? throw new ArgumentNullValueException(nameof(seller));
        StartingPrice = startingPrice ?? throw new ArgumentNullValueException(nameof(startingPrice));
        BidIncrement = bidIncrement ?? throw new ArgumentNullValueException(nameof(bidIncrement));
        RepurchasePrice = repurchasePrice ?? throw new ArgumentNullValueException(nameof(repurchasePrice));

        StartDate = startDate;
        EndDate = endDate;
    }
}
