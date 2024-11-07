using Auction.Common.Domain.Entities;
using Auction.Common.Domain.EntitiesExceptions;
using Auction.Common.Domain.ValueObjects.Numeric;
using Auction.Common.Domain.ValueObjects.String;
using Auction.LotsArchive.Domain.EntitiesExceptions;
using System;

namespace Auction.LotsArchive.Domain.Entities;

/// <summary>
/// Основная информация по лоту
/// </summary>
public class Lot : AbstractLot<Guid>
{
#pragma warning disable IDE0052 // Remove unread private members
    private Guid? _repurchasedLotId;
    private Guid? _withdrawnLotId;
#pragma warning restore IDE0052 // Remove unread private members

    /// <summary>
    /// Продавец
    /// </summary>
    public Seller Seller { get; }

    /// <summary>
    /// Информация о выкупе лота
    /// </summary>
    public RepurchasedLot? RepurchasedLot { get; private set; }

    /// <summary>
    /// Информация об отмене лота
    /// </summary>
    public WithdrawnLot? WithdrawnLot { get; private set; }

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
    public Price? RepurchasePrice { get; }

    /// <summary>
    /// Дата старта торгов по лоту
    /// </summary>
    public DateTime StartDateTime { get; }

    /// <summary>
    /// Дата окончания торгов по лоту
    /// </summary>
    public DateTime EndDateTime { get; }

    /// <summary>
    /// Маркер что лот не был выкуплен
    /// </summary>
    public bool IsUnpurchased { get; private set; }

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
    /// <param name="bidIncrement">Минимальный шаг цены лота</param>
    /// <param name="startDateTime">Дата старта торгов по лоту</param>
    /// <param name="endDateTime">Дата окончания торгов по лоту</param>
    /// <param name="repurchasedLot">Данные опродаже лота</param>
    /// <param name="withdrawnLot">Данные об отмене лота</param>
    /// <exception cref="ArgumentNullValueException">Если аргумент null</exception>
    public Lot(
        Guid id,
        Title title,
        Text description,
        Seller seller,
        Price startingPrice,
        Price bidIncrement,
        Price? repurchasePrice,
        DateTime startDateTime,
        DateTime endDateTime,
        RepurchasedLot? repurchasedLot = null,
        WithdrawnLot? withdrawnLot = null)
            : base(id, title, description)
    {
        GuidEmptyValueException.ThrowIfEmpty(id);

        if (repurchasedLot is not null && withdrawnLot is not null)
        {
            throw new IncompatibleLotArgumentsValuesException(repurchasedLot, withdrawnLot);
        }

        Seller = seller ?? throw new ArgumentNullValueException(nameof(seller));
        StartingPrice = startingPrice ?? throw new ArgumentNullValueException(nameof(startingPrice));
        BidIncrement = bidIncrement ?? throw new ArgumentNullValueException(nameof(bidIncrement));

        RepurchasePrice = repurchasePrice;

        StartDateTime = startDateTime;
        EndDateTime = endDateTime;

        RepurchasedLot = repurchasedLot;
        _repurchasedLotId = repurchasedLot?.Id;

        WithdrawnLot = withdrawnLot;
        _withdrawnLotId = withdrawnLot?.Id;

        IsUnpurchased = repurchasedLot is null && withdrawnLot is null;
    }

    public void SetRepurchasedLot(RepurchasedLot repurchasedLot)
    {
        if (WithdrawnLot is not null)
        {
            throw new InvalidSetRepurchasedLotException(repurchasedLot, WithdrawnLot);
        }

        RepurchasedLot = repurchasedLot ?? throw new ArgumentNullValueException(nameof(repurchasedLot));
        _repurchasedLotId = repurchasedLot.Id;
        IsUnpurchased = false;
    }

    public void SetWithdrawnLot(WithdrawnLot withdrawnLot)
    {
        if (RepurchasedLot is not null)
        {
            throw new InvalidSetWithdrawnLotException(RepurchasedLot, withdrawnLot);
        }

        WithdrawnLot = withdrawnLot ?? throw new ArgumentNullValueException(nameof(withdrawnLot));
        _withdrawnLotId = withdrawnLot.Id;
        IsUnpurchased = false;
    }
}
