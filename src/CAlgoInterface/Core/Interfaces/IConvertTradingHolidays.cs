using CAlgoInterface.Backend.Integrations;

namespace CAlgoInterface.Core.Interfaces;

public interface IConvertTradingHolidays
{
    cAlgo.API.TradingHoliday ToCAlgoTradingHoliday(ITradingHolidayAdapter tradingHolidayAdapter);
    ITradingHoliday ToTradingHoliday(cAlgo.API.TradingHoliday cAlgoTradingHoliday);
}