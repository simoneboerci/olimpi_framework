using System;

namespace CAlgoInterface.Core.Interfaces;

public interface ITradingSession
{
    DayOfWeek StartDay { get; }
    DayOfWeek EndDay { get; }
    TimeSpan StartTime { get; }
    TimeSpan EndTime { get; }   
}