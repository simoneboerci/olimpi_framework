using CAlgoInterface.Core.Interfaces;

namespace CAlgoInterface.Backend.Integrations;

public interface ITradeResultAdapter : ITradeResult
{
    cAlgo.API.TradeResult GetCAlgoTradeResult(ITradeResult tradeResult);
}