using System;
using CAlgoInterface.Core.Interfaces;

namespace CAlgoInterface.Core.Models;

public readonly struct Candlestick : ICandlestick
{
    public DateTime OpenTime { get; }
    public double Open { get; }
    public double High { get; }
    public double Low { get; }
    public double Close { get; }
    public long TickVolume { get; }
    internal Candlestick(DateTime openTime, double open, double high, double low, double close, long tickVolume)
    {
        OpenTime = openTime;
        Open = open;
        High = high;
        Low = low;
        Close = close;
        TickVolume = tickVolume;
    }

    public bool Equals(ICandlestick other) => (ICandlestick)this == other;

    public override bool Equals(object obj)
    {
        if (obj == null) return false;
        if (obj is Candlestick other) return Equals(other);
        return false;
    }

    public override int GetHashCode()
    {
        return ((((OpenTime.GetHashCode() * 397 ^ Open.GetHashCode()) * 397 ^ High.GetHashCode()) * 397 ^ Low.GetHashCode()) * 397 ^ Close.GetHashCode()) * 397 ^ TickVolume.GetHashCode();
    }

    public override string ToString()
    {
        return $"{"OpenTime"}: {OpenTime}, {"Open"}: {Open}, {"High"}: {High}, {"Low"}: {Low}, {"Close"}: {Close}, {"TickVolume"}: {TickVolume}";
    }

    public static bool operator ==(Candlestick left, Candlestick right)
    {
        if (left.OpenTime.Equals(right.OpenTime)
        && left.Open.Equals(right.Open)
        && left.High.Equals(right.High)
        && left.Low.Equals(right.Low)
        && left.Close.Equals(right.Close)
        && left.TickVolume.Equals(right.TickVolume))
        {
            return true;
        }

        return false;
    }
    
    public static bool operator !=(Candlestick left, Candlestick right)
    {
        return !(left == right);
    }
}