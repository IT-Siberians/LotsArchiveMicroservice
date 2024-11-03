using Auction.Common.Domain.Entities;
using Auction.Common.Domain.EntitiesExceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Auction.LotsArchive.Domain.Entities;

/// <summary>
/// Продавец
/// </summary>
public class Seller : IEntity<Guid>//: Person
{
#pragma warning disable IDE0044 // Add readonly modifier
    private ICollection<Lot>? _allLots;
#pragma warning restore IDE0044 // Add readonly modifier

    /// <summary>
    /// Уникальный идентификатор
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Данные человека
    /// </summary>
    public Person PersonInfo { get; }

    /// <summary>
    /// Все лоты выставленные на продажу продавцов
    /// </summary>
    public IReadOnlyCollection<Lot> AllLots => _allLots
        ?.ToList()
        ?? throw new FieldNullValueException(nameof(_allLots));

    /// <summary>
    /// Все лоты проданные продавцом
    /// </summary>
    public IReadOnlyCollection<RepurchasedLot> SoldLots => _allLots
        ?.Where(e => e.RepurchasedLot is not null)
        .Select(e => e.RepurchasedLot!)
        .ToList()
        ?? throw new FieldNullValueException(nameof(_allLots));

    /// <summary>
    /// Все лоты отмененные продавцом
    /// </summary>
    public IReadOnlyCollection<WithdrawnLot> WithdrawnLots => _allLots
        ?.Where(e => e.WithdrawnLot is not null)
        .Select(e => e.WithdrawnLot!)
        .ToList()
        ?? throw new FieldNullValueException(nameof(_allLots));

    /// <summary>
    /// Все невыкупленные лоты продавца
    /// </summary>
    public IReadOnlyCollection<Lot> UnpurchasedLots => _allLots
        ?.Where(e => e.IsUnpurchased)
        .ToList()
        ?? throw new FieldNullValueException(nameof(_allLots));

    /// <summary>
    /// Конструктор для EF
    /// </summary>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected Seller() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    /// <summary>
    /// Основной конструктор продавца
    /// </summary>
    /// <param name="person">Данные продавца</param>
    /// <param name="allLots">Все лоты выставлявшиеся на торги</param>
    /// <exception cref="ArgumentNullValueException">Если аргумент null</exception>
    public Seller(
        Person person,
        ICollection<Lot> allLots)
    {
        PersonInfo = person ?? throw new ArgumentNullValueException(nameof(person));
        _allLots = allLots ?? throw new ArgumentNullValueException(nameof(allLots));
    }
}