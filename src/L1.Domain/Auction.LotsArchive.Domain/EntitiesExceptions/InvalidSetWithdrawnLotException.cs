using Auction.LotsArchive.Domain.Entities;
using System;

namespace Auction.LotsArchive.Domain.EntitiesExceptions;

/// <summary>
/// Доменное исключение для невозможного использования сеттера WithdrawnLot
/// </summary>
/// <param name="repurchasedLot">Значение RepurchasedLot</param>
/// <param name="withdrawnLot">Значение WithdrawnLot</param>
internal class InvalidSetWithdrawnLotException(RepurchasedLot repurchasedLot, WithdrawnLot withdrawnLot)
    : InvalidOperationException($"Cannot set WithdrawnLot value ({withdrawnLot}), because RepurchasedLot value ({repurchasedLot}) is set")
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
