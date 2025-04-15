using CAlgoInterface.Core.Interfaces;

namespace CAlgoInterface.Core.Routing;

public interface ITradingSessionAdapter : ITradingSession, IConvertTradingSessions
{
    cAlgo.API.Internals.TradingSession GetCAlgoTradingSession();
}