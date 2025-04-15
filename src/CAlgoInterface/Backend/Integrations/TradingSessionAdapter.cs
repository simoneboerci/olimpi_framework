using System;
using CAlgoInterface.Core.Interfaces;
using CAlgoInterface.Core.Routing;

namespace CAlgoInterface.Backend.Integrations;

public class TradingSessionAdapter : ITradingSessionAdapter
{
    private readonly cAlgo.API.Internals.TradingSession _cAlgoTradingSession;

    public TradingSessionAdapter(cAlgo.API.Internals.TradingSession cAlgoTradingSession) => _cAlgoTradingSession = cAlgoTradingSession;

    public DayOfWeek StartDay => _cAlgoTradingSession.StartDay;
    public DayOfWeek EndDay => _cAlgoTradingSession.EndDay;
    public TimeSpan StartTime => _cAlgoTradingSession.StartTime;
    public TimeSpan EndTime => _cAlgoTradingSession.EndTime;

    public cAlgo.API.Internals.TradingSession GetCAlgoTradingSession() => _cAlgoTradingSession;

    public cAlgo.API.Internals.TradingSession ToCAlgoTradingSession(ITradingSessionAdapter tradingSessionAdapter) => tradingSessionAdapter.GetCAlgoTradingSession();
    public ITradingSession ToTradingSession(cAlgo.API.Internals.TradingSession cAlgoTradingSession) => new TradingSessionAdapter(cAlgoTradingSession);
}