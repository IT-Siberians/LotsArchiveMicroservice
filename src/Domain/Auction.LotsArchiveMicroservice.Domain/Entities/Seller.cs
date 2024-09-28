using Auction.Common.Domain.Entities;
using Auction.Common.Domain.EntitiesExceptions;
using Auction.Common.Domain.ValueObjects.String;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Auction.LotsArchiveMicroservice.Domain.Entities;

/// <summary>
/// Продавец
/// </summary>
public class Seller : AbstractPerson<Guid>
{
#pragma warning disable IDE0044 // Add readonly modifier
    private ICollection<RepurchasedLot>? _soldLots;
    private ICollection<WithdrawnLot>? _withdrawnLots;
    private ICollection<Lot>? _unpurchasedLots;
#pragma warning restore IDE0044 // Add readonly modifier

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
    /// Конструктор для EF
    /// </summary>
    protected Seller() { }

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
        Username username,
        ICollection<RepurchasedLot> soldLots,
        ICollection<WithdrawnLot> withdrawnLots,
        ICollection<Lot> unpurchasedLots)
            : base(id, username)
    {
        GuidEmptyValueException.ThrowIfEmpty(id);

        _soldLots = soldLots ?? throw new ArgumentNullValueException(nameof(soldLots));
        _withdrawnLots = withdrawnLots ?? throw new ArgumentNullValueException(nameof(withdrawnLots));
        _unpurchasedLots = unpurchasedLots ?? throw new ArgumentNullValueException(nameof(unpurchasedLots));
    }
}