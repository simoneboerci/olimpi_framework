using CAlgoInterface.Core.Interfaces;

namespace CAlgoInterface.Backend.Integrations;

public interface ITradeOperationAdapter : IMarketTradeOperation, IPendingTradeOperation
{
    cAlgo.API.TradeOperation GetCAlgoTradeOperation();

    cAlgo.API.TradeOperation ToCAlgoTradeOperation(ITradeOperationAdapter marketTradeOperation);

    IMarketTradeOperation ToMarketTradeOperation(cAlgo.API.TradeOperation tradeOperation);
    IPendingTradeOperation ToPendingTradeOperation(cAlgo.API.TradeOperation tradeOperation);
}