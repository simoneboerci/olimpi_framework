using System;
using System.Collections.Generic;
using CAlgoInterface.Core.Interfaces;
using CAlgoInterface.Core.Routing;

namespace CAlgoInterface.Backend.Integrations;

public class MarketHoursAdapter : IMarketHoursAdapter
{
    private readonly cAlgo.API.Internals.MarketHours _cAlgoMarketHours;

    private readonly ITradingSessionAdapter _tradingSessionAdapter;
    private readonly ITradingHolidayAdapter _tradingHolidayAdapter;

    public MarketHoursAdapter(
        cAlgo.API.Internals.MarketHours cAlgoMarketHours,
        ITradingSessionAdapter tradingSessionAdapter,
        ITradingHolidayAdapter tradingHolidayAdapter)
    {
        _cAlgoMarketHours = cAlgoMarketHours;
        _tradingSessionAdapter = tradingSessionAdapter;
        _tradingHolidayAdapter = tradingHolidayAdapter;
    }

    public cAlgo.API.Internals.MarketHours CAlgoMarketHours() => _cAlgoMarketHours;

    public IReadOnlyList<ITradingSession> TradingSessions => ConvertCAlgoTradingSessionsToTradingSessions();
    public IReadOnlyList<ITradingHoliday> TradingHolidays => ConvertCAlgoTradingHolidaysToTradingHolidays();

    public bool IsOpened() => _cAlgoMarketHours.IsOpened();
    public bool IsOpened(DateTime dateTime) => _cAlgoMarketHours.IsOpened(dateTime);

    public TimeSpan TimeTillClose() => _cAlgoMarketHours.TimeTillClose();
    public TimeSpan TimeTillOpen() => _cAlgoMarketHours.TimeTillOpen();

    public cAlgo.API.Internals.MarketHours ToCAlgoMarketHours(IMarketHoursAdapter marketHoursAdapter) => marketHoursAdapter.CAlgoMarketHours();
    public IMarketHours ToMarketHours(cAlgo.API.Internals.MarketHours cAlgoMarketHours) => new MarketHoursAdapter(cAlgoMarketHours, _tradingSessionAdapter, _tradingHolidayAdapter);

    private IReadOnlyList<ITradingSession> ConvertCAlgoTradingSessionsToTradingSessions()
    {
        var tradingSessions = new List<ITradingSession>();
        foreach (var session in _cAlgoMarketHours.Sessions)
        {
            var tradingSession = _tradingSessionAdapter.ToTradingSession(session);
            tradingSessions.Add(tradingSession);
        }

        return tradingSessions.AsReadOnly();
    }
    private IReadOnlyList<ITradingHoliday> ConvertCAlgoTradingHolidaysToTradingHolidays()
    {
        var tradingHolidays = new List<ITradingHoliday>();
        foreach (var holiday in _cAlgoMarketHours.Holidays)
        {
            var tradingHoliday = _tradingHolidayAdapter.ToTradingHoliday(holiday);
            tradingHolidays.Add(tradingHoliday);
        }

        return tradingHolidays.AsReadOnly();   
    }
}