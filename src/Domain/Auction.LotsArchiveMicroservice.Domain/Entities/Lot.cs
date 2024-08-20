using Auction.Common.Domain.Entities;
using Auction.Common.Domain.Exceptions;
using Auction.Common.Domain.ValueObjects;
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
    public Money StartingPrice { get; }

    /// <summary>
    /// Минимальный шаг цены
    /// </summary>
    public Money PriceStep { get; }

    /// <summary>
    /// Дата старта торгов по лоту
    /// </summary>
    public DateTime StartDate { get; }

    /// <summary>
    /// Дата окончания торгов по лоту
    /// </summary>
    public DateTime? EndDate { get; protected set; }

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
        Name title,
        Text description,
        Seller seller,
        Money startingPrice,
        Money priceStep,
        DateTime startDate,
        DateTime? endDate = null)
        : base(id, title, description)
    {
        Seller = seller ?? throw new ArgumentNullValueException(nameof(seller));
        StartingPrice = startingPrice ?? throw new ArgumentNullValueException(nameof(startingPrice));
        PriceStep = priceStep ?? throw new ArgumentNullValueException(nameof(priceStep));

        StartDate = startDate;
        EndDate = endDate;
    }
}
