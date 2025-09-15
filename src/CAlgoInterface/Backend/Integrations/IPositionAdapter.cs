using OrderExecution.Core.Interfaces;

namespace CAlgoInterface.Backend.Integrations;

public interface IPositionAdapter : IPosition
{
    cAlgo.API.Position GetCAlgoPosition();
}