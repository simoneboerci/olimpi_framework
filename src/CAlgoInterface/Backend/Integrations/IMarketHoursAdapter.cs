using CAlgoInterface.Core.Interfaces;

namespace CAlgoInterface.Backend.Integrations;

public interface IMarketHoursAdapter : IMarketHours, IConvertMarketHours
{
    cAlgo.API.Internals.MarketHours CAlgoMarketHours();
}