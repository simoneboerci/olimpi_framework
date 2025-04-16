using CAlgoInterface.Core.Routing;
using OrderCreation;

namespace CAlgoInterface.Backend.Routing;

public class StopTriggerMethodMapper : IStopTriggerMethodMapper
{
    public cAlgo.API.StopTriggerMethod ToCAlgoStopTriggerMethod(StopTriggerMethod stopTriggerMethod)
    {
        return stopTriggerMethod switch
        {
            StopTriggerMethod.Trade => cAlgo.API.StopTriggerMethod.Trade,
            StopTriggerMethod.Opposite => cAlgo.API.StopTriggerMethod.Opposite,
            StopTriggerMethod.DoubleTrade => cAlgo.API.StopTriggerMethod.DoubleTrade,
            StopTriggerMethod.DoubleOpposite => cAlgo.API.StopTriggerMethod.DoubleOpposite,
            _ => throw new System.NotImplementedException()
        };
    }

    public StopTriggerMethod ToCustomStopTriggerMethod(cAlgo.API.StopTriggerMethod cAlgoStopTriggerMethod)
    {
        return cAlgoStopTriggerMethod switch
        {
            cAlgo.API.StopTriggerMethod.Trade => StopTriggerMethod.Trade,
            cAlgo.API.StopTriggerMethod.Opposite => StopTriggerMethod.Opposite,
            cAlgo.API.StopTriggerMethod.DoubleTrade => StopTriggerMethod.DoubleTrade,
            cAlgo.API.StopTriggerMethod.DoubleOpposite => StopTriggerMethod.DoubleOpposite,
            _ => throw new System.NotImplementedException()
        };
    }
}