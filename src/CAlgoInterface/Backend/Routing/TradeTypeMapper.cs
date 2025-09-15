using CAlgoInterface.Core.Routing;
using OrderCreation.Core.Enums;

namespace CAlgoInterface.Backend.Routing;

public class TradeTypeMapper : ITradeTypeMapper
{
    public cAlgo.API.TradeType ToCAlgoTradeType(TradeType tradeType)
    {
        return tradeType switch
        {
            TradeType.Buy => cAlgo.API.TradeType.Buy,
            TradeType.Sell => cAlgo.API.TradeType.Sell,
            _ => throw new System.NotImplementedException(),
        };
    }

    public TradeType ToTradeType(cAlgo.API.TradeType cAlgoTradeType)
    {
        return cAlgoTradeType switch
        {
            cAlgo.API.TradeType.Buy => TradeType.Buy,
            cAlgo.API.TradeType.Sell => TradeType.Sell,
            _ => throw new System.NotImplementedException(),
        };
    }
}