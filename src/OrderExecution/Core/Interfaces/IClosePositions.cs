using System;

namespace OrderExecution.Core.Interfaces;

public interface IClosePositions
{
    ITradeResult ClosePosition(IPosition position);
    ITradeResult ClosePosition(IPosition position, long volume);
    ITradeResult ClosePosition(IPosition position, double volume);

    ITradeResultAsync ClosePositionAsync(IPosition position, Action<ITradeResult> callback = null);
    ITradeResultAsync ClosePositionAsync(IPosition position, long volume, Action<ITradeResult> callback = null);
    ITradeResultAsync ClosePositionAsync(IPosition position, double volume, Action<ITradeResult> callback = null);
}