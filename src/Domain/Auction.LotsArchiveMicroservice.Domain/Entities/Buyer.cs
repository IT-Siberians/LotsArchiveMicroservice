using Auction.Common.Domain.Entities;
using Auction.Common.Domain.Exceptions;
using Auction.Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Auction.LotsArchiveMicroservice.Domain.Entities;

/// <summary>
/// Покупатель
/// </summary>
public class Buyer : AbstractPerson<Guid>
{
    private ICollection<RepurchasedLot>? _boughtLots;

    /// <summary>
    /// Все лоты, купленные покупателем
    /// </summary>
    public IReadOnlyCollection<RepurchasedLot> BoughtLots => _boughtLots
        ?.ToList()
        ?? throw new FieldNullValueException(nameof(_boughtLots));

    /// <summary>
    /// Основной конструктор покупателя
    /// </summary>
    /// <param name="id">Уникальный идентификатор покупателя</param>
    /// <param name="username">Имя покупателя</param>
    /// <param name="boughtLots">Коллекция купленных лотов</param>
    /// <exception cref="ArgumentNullValueException">Если аргумент null</exception>
    public Buyer(
        Guid id,
        Name username,
        ICollection<RepurchasedLot> boughtLots)
        : base(id, username)
    {
        _boughtLots = boughtLots ?? throw new ArgumentNullValueException(nameof(boughtLots));
    }
}
