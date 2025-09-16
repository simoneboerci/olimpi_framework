using CAlgoInterface.Core.Interfaces;

namespace CAlgoInterface.Backend.Integrations;

public interface ITradeOperationAdapter : ITradeOperation
{
    cAlgo.API.TradeOperation GetCAlgoTradeOperation();
}