namespace CAlgoInterface.Core.Interfaces;

public interface IPendingTradeOperation : ITradeOperation
{
    IPendingTradeResult PendingTradeResult{ get; }
}