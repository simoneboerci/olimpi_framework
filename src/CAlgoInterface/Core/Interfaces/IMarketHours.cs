using System;
using System.Collections.Generic;

namespace CAlgoInterface.Core.Interfaces;

public interface IMarketHours
{
    IReadOnlyList<ITradingSession> TradingSessions { get; }
    IReadOnlyList<ITradingHoliday> TradingHolidays { get; }
    bool IsOpened();
    bool IsOpened(DateTime dateTime);
    TimeSpan TimeTillClose();
    TimeSpan TimeTillOpen();
}