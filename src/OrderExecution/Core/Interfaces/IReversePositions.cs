using System;

namespace OrderExecution.Core.Interfaces;

public interface IReversePositions
{
    ITradeResult ReversePosition(IPosition position);
    ITradeResult ReversePosition(IPosition position, double volume);

    ITradeResultAsync ReversePositionAsync(IPosition position, Action<ITradeResult> callback = null);
    ITradeResultAsync ReversePositionAsync(IPosition position, double volume, Action<ITradeResult> callback = null);
}