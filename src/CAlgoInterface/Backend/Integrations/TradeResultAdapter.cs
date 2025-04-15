using CAlgoInterface.Core.Interfaces;

namespace CAlgoInterface.Backend.Integrations;

public class TradeResultAdapter : ITradeResultAdapter
{   
    private readonly cAlgo.API.TradeResult _cAlgoTradeResult;

    public bool IsSuccessful => _cAlgoTradeResult.IsSuccessful;

    public TradeResultAdapter(cAlgo.API.TradeResult tradeResult) => _cAlgoTradeResult = tradeResult;

    public cAlgo.API.TradeResult GetCAlgoTradeResult() => _cAlgoTradeResult;

    public cAlgo.API.TradeResult ToCAlgoTradeResult(ITradeResultAdapter tradeResultAdapter) => tradeResultAdapter.GetCAlgoTradeResult();

    public IMarketTradeResult ToMarketTradeResult(cAlgo.API.TradeResult tradeResult) => new TradeResultAdapter(_cAlgoTradeResult);
    public IPendingTradeResult ToPendingTradeResult(cAlgo.API.TradeResult tradeResult) => new TradeResultAdapter(_cAlgoTradeResult);
}
