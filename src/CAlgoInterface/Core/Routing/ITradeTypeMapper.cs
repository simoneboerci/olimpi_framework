using CAlgoInterface.Core.Enums;

namespace CAlgoInterface.Core.Routing;

public interface ITradeTypeMapper
{
    cAlgo.API.TradeType ToCAlgoTradeType(TradeType tradeType);
    TradeType ToTradeType(cAlgo.API.TradeType cAlgoTradeType);
}