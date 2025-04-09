using cAlgo.API;
using CAlgoInterface.Backend.Integrations;

namespace CAlgoInterface.Core.Interfaces;

public interface IConvertCandlesticks
{
    Bar ToCAlgoBar(ICandlestickAdapter candlestickAdapter);
    ICandlestick ToCandlestick(Bar bar);
}