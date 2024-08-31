using Auction.Common.Domain.Entities;
using Auction.Common.Domain.EntitiesExceptions;
using Auction.Common.Domain.ValueObjects.String;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Auction.LotsArchiveMicroservice.Domain.Entities;

/// <summary>
/// Покупатель
/// </summary>
public class Buyer : AbstractPerson<Guid>
{
#pragma warning disable IDE0044 // Add readonly modifier
    private ICollection<RepurchasedLot>? _boughtLots;
#pragma warning restore IDE0044 // Add readonly modifier

    /// <summary>
    /// Все лоты, купленные покупателем
    /// </summary>
    public IReadOnlyCollection<RepurchasedLot> BoughtLots => _boughtLots
        ?.ToList()
        ?? throw new FieldNullValueException(nameof(_boughtLots));

    /// <summary>
    /// Конструктор для EF
    /// </summary>
    protected Buyer() { }

    /// <summary>
    /// Основной конструктор покупателя
    /// </summary>
    /// <param name="id">Уникальный идентификатор покупателя</param>
    /// <param name="username">Имя покупателя</param>
    /// <param name="boughtLots">Коллекция купленных лотов</param>
    /// <exception cref="ArgumentNullValueException">Если аргумент null</exception>
    public Buyer(
        Guid id,
        PersonName username,
        ICollection<RepurchasedLot> boughtLots)
            : base(id, username)
    {
        GuidEmptyValueException.ThrowIfEmpty(id);

        _boughtLots = boughtLots ?? throw new ArgumentNullValueException(nameof(boughtLots));
    }
}
