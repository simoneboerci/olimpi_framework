using CAlgoInterface.Core.Routing;

namespace CAlgoInterface.Core.Interfaces;

public interface IConvertTradingSessions
{
    cAlgo.API.Internals.TradingSession ToCAlgoTradingSession(ITradingSessionAdapter tradingSessionAdapter);
    ITradingSession ToTradingSession(cAlgo.API.Internals.TradingSession cAlgoTradingSession);
}