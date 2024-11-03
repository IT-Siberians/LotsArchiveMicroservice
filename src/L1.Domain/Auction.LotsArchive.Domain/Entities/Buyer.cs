using Auction.Common.Domain.Entities;
using Auction.Common.Domain.EntitiesExceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Auction.LotsArchive.Domain.Entities;

/// <summary>
/// Покупатель
/// </summary>
public class Buyer : IEntity<Guid>//: Person
{
#pragma warning disable IDE0044 // Add readonly modifier
    private ICollection<RepurchasedLot>? _boughtLots;
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
    /// Все лоты, купленные покупателем
    /// </summary>
    public IReadOnlyCollection<RepurchasedLot> BoughtLots => _boughtLots
        ?.ToList()
        ?? throw new FieldNullValueException(nameof(_boughtLots));

    /// <summary>
    /// Конструктор для EF
    /// </summary>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected Buyer() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.


    /// <summary>
    /// Основной конструктор покупателя
    /// </summary>
    /// <param name="person">Данные покупателя</param>
    /// <param name="boughtLots">Коллекция купленных лотов</param>
    /// <exception cref="ArgumentNullValueException">Если аргумент null</exception>
    public Buyer(
        Person person,
        ICollection<RepurchasedLot> boughtLots)
    {
        PersonInfo = person ?? throw new ArgumentNullValueException(nameof(person));
        _boughtLots = boughtLots ?? throw new ArgumentNullValueException(nameof(boughtLots));
    }
}
