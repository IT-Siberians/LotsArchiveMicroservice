using Auction.LotsArchive.Domain.Entities;
using System;

namespace Auction.LotsArchive.Domain.EntitiesExceptions;

/// <summary>
/// Исключение домена для несовместимых значений аргумента конструктора лота
/// </summary>
/// <param name="repurchasedLot">Значение RepurchasedLot</param>
/// <param name="withdrawnLot">Значение WithdrawnLot</param>
internal class IncompatibleLotArgumentsValuesException(
    RepurchasedLot repurchasedLot,
    WithdrawnLot withdrawnLot)
    : ArgumentException($"Both arguments (repurchasedLot & withdrawnLot) cannot be specified to be non-null at the same time, repurchasedLot: \"{repurchasedLot}\", withdrawnLot: \"{repurchasedLot}\".")
{
    /// <summary>
    /// Значение RepurchasedLot
    /// </summary>
    public RepurchasedLot RepurchasedLot { get; } = repurchasedLot;

    /// <summary>
    /// Значение WithdrawnLot
    /// </summary>
    public WithdrawnLot WithdrawnLot { get; } = withdrawnLot;
}
