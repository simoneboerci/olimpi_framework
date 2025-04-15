using CAlgoInterface.Core.Routing;

namespace CAlgoInterface.Backend.Routing;

public abstract class OrderMapperBase<TCustomOrder, TCAlgoOrderStruct> : IOrderMapper<TCustomOrder, TCAlgoOrderStruct>
{
    protected readonly ITradeTypeMapper TradeTypeMapper;
    protected readonly IStopTriggerMethodMapper StopTriggerMethodMapper;

    public OrderMapperBase(ITradeTypeMapper tradeTypeMapper, IStopTriggerMethodMapper stopTriggerMethodMapper)
    {
        TradeTypeMapper = tradeTypeMapper;
        StopTriggerMethodMapper = stopTriggerMethodMapper;
    }

    public abstract TCAlgoOrderStruct Map(TCustomOrder customOrder);
}