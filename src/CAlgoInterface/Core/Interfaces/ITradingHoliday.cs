using System;

namespace CAlgoInterface.Core.Interfaces;

public interface ITradingHoliday
{
    string Name { get; }
    DateTime StartTime { get; }
    DateTime EndTime { get; }
    bool IsRecurring { get; }
}