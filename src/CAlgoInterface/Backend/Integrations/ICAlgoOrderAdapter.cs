using CAlgoInterface.Core.Data;
using CAlgoInterface.Core.Interfaces;

namespace CAlgoInterface.Backend.Integrations;

public interface ICAlgoOrderAdapter
{
    CAlgoMarketOrderStruct ToCAlgoMarketOrder(IMarketOrder marketOrder);
    CAlgoMarketRangeOrderStruct ToCAlgoMarketRangeOrder(IMarketRangeOrder marketRangeOrder);
    CAlgoLimitOrderStruct ToCAlgoLimitOrder(ILimitOrder limitOrder);
    CAlgoStopOrderStruct ToCAlgoStopOrder(IStopOrder stopOrder);
    CAlgoStopLimitOrderStruct ToCAlgoStopLimitOrder(IStopLimitOrder stopLimitOrder);
}