using CAlgoInterface.Core.Interfaces;

namespace CAlgoInterface.Backend.Integrations;

public interface ITradeResultAdapter : IMarketTradeResult, IPendingTradeResult
{
    cAlgo.API.TradeResult GetCAlgoTradeResult();

    cAlgo.API.TradeResult ToCAlgoTradeResult(ITradeResultAdapter marketTradeResult);

    IMarketTradeResult ToMarketTradeResult(cAlgo.API.TradeResult tradeResult);
    IPendingTradeResult ToPendingTradeResult(cAlgo.API.TradeResult tradeResult);
}