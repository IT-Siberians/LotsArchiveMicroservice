using Auction.LotsArchive.Domain.Entities;
using System;

namespace Auction.LotsArchive.Domain.EntitiesExceptions;

/// <summary>
/// Доменное исключение для невозможного использования сеттера RepurchasedLot
/// </summary>
/// <param name="repurchasedLot">Значение RepurchasedLot</param>
/// <param name="withdrawnLot">Значение WithdrawnLot</param>
internal class InvalidSetRepurchasedLotException(RepurchasedLot repurchasedLot, WithdrawnLot withdrawnLot)
    : InvalidOperationException($"Cannot set RepurchasedLot value ({repurchasedLot}), because WithdrawnLot value ({withdrawnLot}) is set")
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
