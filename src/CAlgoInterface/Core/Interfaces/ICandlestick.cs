using System;

namespace CAlgoInterface.Core.Interfaces;

public interface ICandlestick : IEquatable<ICandlestick>
{
    public DateTime OpenTime { get; }
    public double Open { get; }
    public double High { get; }
    public double Low { get; }
    public double Close { get; }
    public long TickVolume { get; }
    
}