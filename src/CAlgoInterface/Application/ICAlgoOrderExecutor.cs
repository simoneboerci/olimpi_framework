using CAlgoInterface.Core.Interfaces;

namespace CAlgoInterface.Application;

public interface ICAlgoOrderExecutor : IExecuteCAlgoLimitOrders, IExecuteCAlgoMarketOrders, IExecuteCAlgoMarketRangeOrders, IExecuteCAlgoStopLimitOrders, IExecuteCAlgoStopOrders
{
    
}