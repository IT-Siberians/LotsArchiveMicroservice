using Auction.Common.Domain.Entities;
using Auction.Common.Domain.Exceptions;
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
    /// Основной конструктор информации об отмене лота
    /// </summary>
    /// <param name="id">Уникальный идентификатор записи об отмене лота</param>
    /// <param name="date">Дата отмены лота</param>
    /// <param name="lot">Отмененный лот</param>
    /// <exception cref="ArgumentNullValueException">Если аргумент null</exception>
    public WithdrawnLot(Guid id, DateTime date, Lot lot)
    {
        Lot = lot ?? throw new ArgumentNullValueException(nameof(lot));

        Id = id;
        Date = date;
    }
}
