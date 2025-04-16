using System;
using cAlgo.API;

namespace CAlgoInterface.Core.Interfaces;

public interface ICancelPendingOrders
{
    #region Cancel Pending Orders

    TradeResult CancelPendingOrder(PendingOrder pendingOrder);

    #endregion

    #region Cancel Pending Orders Async

    TradeOperation CancelPendingOrderAsync(PendingOrder pendingOrder, Action<TradeResult> callback = null);

    #endregion
}