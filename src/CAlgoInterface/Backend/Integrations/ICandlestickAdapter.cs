using cAlgo.API;
using CAlgoInterface.Core.Interfaces;

namespace CAlgoInterface.Backend.Integrations;

public interface ICandlestickAdapter : ICandlestick, IConvertCandlesticks
{
    Bar GetCAlgoBar();
}