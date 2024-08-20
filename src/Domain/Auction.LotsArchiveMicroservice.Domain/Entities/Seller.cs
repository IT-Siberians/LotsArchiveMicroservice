using Auction.Common.Domain.Entities;
using Auction.Common.Domain.Exceptions;
using Auction.Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Auction.LotsArchiveMicroservice.Domain.Entities;

/// <summary>
/// Продавец
/// </summary>
public class Seller : AbstractPerson<Guid>
{
    private ICollection<RepurchasedLot>? _soldLots;
    private ICollection<WithdrawnLot>? _withdrawnLots;
    private ICollection<Lot>? _unpurchasedLots;

    /// <summary>
    /// Все лоты проданные продавцом
    /// </summary>
    public IReadOnlyCollection<RepurchasedLot> SoldLots => _soldLots
        ?.ToList()
        ?? throw new FieldNullValueException(nameof(_soldLots));

    /// <summary>
    /// Все лоты отмененные продавцом
    /// </summary>
    public IReadOnlyCollection<WithdrawnLot> WithdrawnLots => _withdrawnLots
        ?.ToList()
        ?? throw new FieldNullValueException(nameof(_withdrawnLots));

    /// <summary>
    /// Все невыкупленные лоты продавца
    /// </summary>
    public IReadOnlyCollection<Lot> UnpurchasedLots => _unpurchasedLots
        ?.ToList()
        ?? throw new FieldNullValueException(nameof(_unpurchasedLots));

    /// <summary>
    /// Основной конструктор продавца
    /// </summary>
    /// <param name="id">Уникальный идентификатор продавца</param>
    /// <param name="username">Имя продавца</param>
    /// <param name="soldLots">Проданные лоты</param>
    /// <param name="withdrawnLots">Отмененные лоты</param>
    /// <param name="unpurchasedLots">Невыкупленные лоты</param>
    /// <exception cref="ArgumentNullValueException">Если аргумент null</exception>
    public Seller(
        Guid id,
        Name username,
        ICollection<RepurchasedLot> soldLots,
        ICollection<WithdrawnLot> withdrawnLots,
        ICollection<Lot> unpurchasedLots)
        : base(id, username)
    {
        _soldLots = soldLots ?? throw new ArgumentNullValueException(nameof(soldLots));
        _withdrawnLots = withdrawnLots ?? throw new ArgumentNullValueException(nameof(withdrawnLots));
        _unpurchasedLots = unpurchasedLots ?? throw new ArgumentNullValueException(nameof(unpurchasedLots));
    }
}