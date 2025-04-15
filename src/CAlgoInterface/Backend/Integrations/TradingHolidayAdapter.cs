using System;
using CAlgoInterface.Core.Interfaces;

namespace CAlgoInterface.Backend.Integrations;

public class TradingHolidayAdapter : ITradingHolidayAdapter
{
    private readonly cAlgo.API.TradingHoliday _cAlgoTradingHoliday;

    public TradingHolidayAdapter(cAlgo.API.TradingHoliday cAlgoTradingHoliday) => _cAlgoTradingHoliday = cAlgoTradingHoliday;

    public string Name => _cAlgoTradingHoliday.Name;
    public DateTime StartTime => _cAlgoTradingHoliday.StartTime;
    public DateTime EndTime => _cAlgoTradingHoliday.EndTime;
    public bool IsRecurring => _cAlgoTradingHoliday.IsRecurring;

    public cAlgo.API.TradingHoliday GetCAlgoTradingHoliday() => _cAlgoTradingHoliday;

    public cAlgo.API.TradingHoliday ToCAlgoTradingHoliday(ITradingHolidayAdapter tradingHolidayAdapter) => tradingHolidayAdapter.GetCAlgoTradingHoliday();
    public ITradingHoliday ToTradingHoliday(cAlgo.API.TradingHoliday cAlgoTradingHoliday) => new TradingHolidayAdapter(cAlgoTradingHoliday);
}