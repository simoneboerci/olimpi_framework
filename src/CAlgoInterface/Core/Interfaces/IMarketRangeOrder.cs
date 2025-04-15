namespace CAlgoInterface.Core.Interfaces;

public interface IMarketRangeOrder : IOrder
{
    double MarketRangePips { get; }
    double BasePrice{ get; }
}