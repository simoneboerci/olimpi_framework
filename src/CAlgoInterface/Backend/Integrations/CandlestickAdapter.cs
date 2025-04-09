using System;
using cAlgo.API;
using CAlgoInterface.Core.Interfaces;

namespace CAlgoInterface.Backend.Integrations;

public class CandlestickAdapter : ICandlestickAdapter
{
    private readonly Bar _bar;

    public CandlestickAdapter(Bar bar) => _bar = bar;

    public Bar GetCAlgoBar() => _bar;

    public DateTime OpenTime => _bar.OpenTime;

    public double Open => _bar.Open;
    public double High => _bar.High;
    public double Low => _bar.Low;  
    public double Close => _bar.Close;  

    public long TickVolume => _bar.TickVolume;

    public bool Equals(ICandlestick other) => this == other;

    public ICandlestick ToCandlestick(Bar bar) => new CandlestickAdapter(bar);
    public Bar ToCAlgoBar(ICandlestickAdapter candlestickAdapter) => candlestickAdapter.GetCAlgoBar();
}