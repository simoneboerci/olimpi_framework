using CAlgoInterface.Core.Data;
using CAlgoInterface.Core.Interfaces;
using CAlgoInterface.Core.Routing;

namespace CAlgoInterface.Backend.Routing;

public class MarketOrderMapper : OrderMapperBase<IMarketOrder, CAlgoMarketOrderStruct>
{
    public MarketOrderMapper(
        ITradeTypeMapper tradeTypeMapper,
        IStopTriggerMethodMapper stopTriggerMethodMapper
    ) : base(
        tradeTypeMapper,
        stopTriggerMethodMapper
    ){}

    public override CAlgoMarketOrderStruct Map(IMarketOrder customOrder)
    {
        return new CAlgoMarketOrderStruct(
            TradeTypeMapper.ToCAlgoTradeType(customOrder.TradeType),
            customOrder.SymbolName,
            customOrder.Volume,
            customOrder.Label,
            customOrder.StopLossPips,
            customOrder.TakeProfitPips,
            customOrder.Comment,
            customOrder.HasTrailingStop,
            customOrder.StopTriggerMethod == null ? null : StopTriggerMethodMapper.ToCAlgoStopTriggerMethod(customOrder.StopTriggerMethod.Value)
        );
    }
}
