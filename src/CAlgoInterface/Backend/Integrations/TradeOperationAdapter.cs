using CAlgoInterface.Core.Interfaces;

namespace CAlgoInterface.Backend.Integrations;

public class TradeOperationAdapter : ITradeOperationAdapter
{
    private readonly cAlgo.API.TradeOperation _cAlgoTradeOperation;

    private readonly ITradeResultAdapter _tradeResultAdapter;

    public TradeOperationAdapter(cAlgo.API.TradeOperation tradeOperation, ITradeResultAdapter tradeResultAdapter)
    {
        _cAlgoTradeOperation = tradeOperation;
        _tradeResultAdapter = tradeResultAdapter;
    }

    public IMarketTradeResult marketTradeResult => _tradeResultAdapter.ToMarketTradeResult(_cAlgoTradeOperation.TradeResult);
    public IPendingTradeResult PendingTradeResult => _tradeResultAdapter.ToPendingTradeResult(_cAlgoTradeOperation.TradeResult);

    public bool IsExecuting => throw new System.NotImplementedException();

    public cAlgo.API.TradeOperation GetCAlgoTradeOperation() => _cAlgoTradeOperation;

    public cAlgo.API.TradeOperation ToCAlgoTradeOperation(ITradeOperationAdapter marketTradeOperation) => marketTradeOperation.GetCAlgoTradeOperation();

    public IMarketTradeOperation ToMarketTradeOperation(cAlgo.API.TradeOperation tradeOperation) => new TradeOperationAdapter(_cAlgoTradeOperation, _tradeResultAdapter);
    public IPendingTradeOperation ToPendingTradeOperation(cAlgo.API.TradeOperation tradeOperation) => new TradeOperationAdapter(_cAlgoTradeOperation, _tradeResultAdapter);
}