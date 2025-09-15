using OrderCreation.Core.Enums;

namespace CAlgoInterface.Core.Routing;

public interface IStopTriggerMethodMapper
{
    cAlgo.API.StopTriggerMethod ToCAlgoStopTriggerMethod(StopTriggerMethod stopTriggerMethod);
    StopTriggerMethod ToCustomStopTriggerMethod(cAlgo.API.StopTriggerMethod cAlgoStopTriggerMethod);
}