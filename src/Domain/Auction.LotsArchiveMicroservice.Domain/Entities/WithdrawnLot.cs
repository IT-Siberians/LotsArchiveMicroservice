using Auction.Common.Domain.Entities;
using Auction.Common.Domain.EntitiesExceptions;
using System;

namespace Auction.LotsArchiveMicroservice.Domain.Entities;

/// <summary>
/// Информация об отмене лота
/// </summary>
public class WithdrawnLot : IEntity<Guid>
{
    /// <summary>
    /// Уникальный идентификатор записи об отмене лота
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Дата отмены лота
    /// </summary>
    public DateTime Date { get; }

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
    /// <param name="date">Дата отмены лота</param>
    /// <param name="lot">Отмененный лот</param>
    /// <exception cref="ArgumentNullValueException">Если аргумент null</exception>
    public WithdrawnLot(Guid id, DateTime date, Lot lot)
    {
        Id = GuidEmptyValueException.GetGuidOrThrowIfEmpty(id);

        Lot = lot ?? throw new ArgumentNullValueException(nameof(lot));

        Date = date;
    }
}
