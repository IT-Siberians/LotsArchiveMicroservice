using Auction.Common.Domain.Entities;
using Auction.Common.Domain.EntitiesExceptions;
using Auction.Common.Domain.ValueObjects.String;
using System;

namespace Auction.LotsArchive.Domain.Entities;

/// <summary>
/// Пользователь
/// </summary>
public class Person : AbstractPerson<Guid>
{
    /// <summary>
    /// Данные покупателя
    /// </summary>
    public Buyer BuyerInfo { get; }

    /// <summary>
    /// Данные продавца
    /// </summary>
    public Seller SellerInfo { get; }

    /// <summary>
    /// Конструктор для EF
    /// </summary>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected Person() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    /// <summary>
    /// Основной конструктор пользователя
    /// </summary>
    /// <param name="id">Уникальный идентификатор пользователя</param>
    /// <param name="username">Имя пользователя</param>
    /// <exception cref="ArgumentNullValueException">Если аргумент null</exception>
    public Person(
        Guid id,
        Username username)
            : base(id, username)
    {
        GuidEmptyValueException.ThrowIfEmpty(id);

        BuyerInfo = new Buyer(this, []);
        SellerInfo = new Seller(this, []);
    }
}
