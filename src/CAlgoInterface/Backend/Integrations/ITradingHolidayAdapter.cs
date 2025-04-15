using CAlgoInterface.Core.Interfaces;

namespace CAlgoInterface.Backend.Integrations;

public interface ITradingHolidayAdapter :  ITradingHoliday, IConvertTradingHolidays
{
    cAlgo.API.TradingHoliday GetCAlgoTradingHoliday();
}