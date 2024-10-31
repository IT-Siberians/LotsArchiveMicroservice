using System;

namespace Auction.Common.Application.Interfaces.Models;

public interface IModel<out TKey>
    where TKey : struct, IEquatable<TKey>
{
    public TKey Id { get; }
}
