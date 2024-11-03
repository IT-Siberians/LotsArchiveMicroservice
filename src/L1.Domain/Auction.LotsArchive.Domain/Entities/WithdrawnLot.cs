using Auction.Common.Domain.Entities;
using Auction.Common.Domain.EntitiesExceptions;
using System;

namespace Auction.LotsArchive.Domain.Entities;

/// <summary>
/// Информация об отмене лота
/// </summary>
public class WithdrawnLot : IEntity<Guid>
{
#pragma warning disable IDE0044 // Add readonly modifier
#pragma warning disable IDE0051 // Remove unused private members
    private Guid _lotId;
#pragma warning restore IDE0051 // Remove unused private members
#pragma warning restore IDE0044 // Add readonly modifier

    /// <summary>
    /// Уникальный идентификатор записи об отмене лота
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Дата отмены лота
    /// </summary>
    public DateTime DateTime { get; }

    /// <summary>
    /// Отмененный лот
    /// </summary>
    public Lot Lot { get; }

    /// <summary>
    /// Конструктор для EF
    /// </summary>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected WithdrawnLot() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    /// <summary>
    /// Основной конструктор информации об отмене лота
    /// </summary>
    /// <param name="id">Уникальный идентификатор записи об отмене лота</param>
    /// <param name="dateTime">Дата отмены лота</param>
    /// <param name="lot">Отмененный лот</param>
    /// <exception cref="ArgumentNullValueException">Если аргумент null</exception>
    public WithdrawnLot(Guid id, DateTime dateTime, Lot lot)
    {
        Id = GuidEmptyValueException.GetGuidOrThrowIfEmpty(id);

        Lot = lot ?? throw new ArgumentNullValueException(nameof(lot));

        DateTime = dateTime;
    }
}
