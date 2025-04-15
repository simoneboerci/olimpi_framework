using System;

namespace OrderExecution.Core.Interfaces;

public interface ICancelPendingPositions
{
    ITradeResult CancelPendingPosition(IPendingPosition pendingPosition);
    ITradeResultAsync CancelPendingPositionAsync(IPendingPosition pendingPosition, Action<ITradeResult> callback = null);
}