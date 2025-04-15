namespace CAlgoInterface.Core.Interfaces;

public interface IMarketTradeOperation : ITradeOperation
{
    IMarketTradeResult marketTradeResult{ get; }
}