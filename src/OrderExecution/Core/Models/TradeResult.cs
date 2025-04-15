using OrderExecution.Core.Interfaces;

namespace OrderExecution.Core.Models;

public readonly struct TradeResult : ITradeResult
{
    public IPosition Position { get; }

    public TradeResult(IPosition position)
    {
        Position = position;
    } 
}