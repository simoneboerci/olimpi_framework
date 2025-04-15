using CAlgoInterface.Core.Routing;

namespace CAlgoInterface.Backend.Routing;

public class StopTriggerMethodMapper : IStopTriggerMethodMapper
{
    public cAlgo.API.StopTriggerMethod ToCAlgoStopTriggerMethod(Core.Enums.StopTriggerMethod stopTriggerMethod)
    {
        return stopTriggerMethod switch
        {
            Core.Enums.StopTriggerMethod.Trade => cAlgo.API.StopTriggerMethod.Trade,
            Core.Enums.StopTriggerMethod.Opposite => cAlgo.API.StopTriggerMethod.Opposite,
            Core.Enums.StopTriggerMethod.DoubleTrade => cAlgo.API.StopTriggerMethod.DoubleTrade,
            Core.Enums.StopTriggerMethod.DoubleOpposite => cAlgo.API.StopTriggerMethod.DoubleOpposite,
            _ => throw new System.NotImplementedException()
        };
    }

    public Core.Enums.StopTriggerMethod ToCustomStopTriggerMethod(cAlgo.API.StopTriggerMethod cAlgoStopTriggerMethod)
    {
        return cAlgoStopTriggerMethod switch
        {
            cAlgo.API.StopTriggerMethod.Trade => Core.Enums.StopTriggerMethod.Trade,
            cAlgo.API.StopTriggerMethod.Opposite => Core.Enums.StopTriggerMethod.Opposite,
            cAlgo.API.StopTriggerMethod.DoubleTrade => Core.Enums.StopTriggerMethod.DoubleTrade,
            cAlgo.API.StopTriggerMethod.DoubleOpposite => Core.Enums.StopTriggerMethod.DoubleOpposite,
            _ => throw new System.NotImplementedException()
        };
    }
}