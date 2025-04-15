using OrderExecution.Core.Interfaces;

namespace OrderExecution.Core.Models;

public readonly struct TradeResultAsync : ITradeResultAsync
{
    public ITradeResult TradeResult { get; }

    public TradeResultAsync(ITradeResult tradeResult)
    {
        TradeResult = tradeResult;
    }
}