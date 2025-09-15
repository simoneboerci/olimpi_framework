using cAlgo.API;
using OrderExecution.Core.Interfaces;

namespace CAlgoInterface.Backend.Integrations;

public class TradeResultAdapter : ITradeResultAdapter
{
    private readonly TradeResult _cAlgoTradeResult;

    private readonly PositionAdapter _positionAdapter;

    public TradeResultAdapter(TradeResult cAlgoTradeResult, PositionAdapter positionAdapter)
    {
        _cAlgoTradeResult = cAlgoTradeResult;
        _positionAdapter = positionAdapter;
    }

    public IPosition Position => _positionAdapter;
    public TradeResult GetCAlgoTradeResult(ITradeResult tradeResult) => _cAlgoTradeResult;
}