using CAlgoInterface.Backend.Integrations;

namespace CAlgoInterface.Core.Interfaces
{
    public interface IConvertMarketHours
    {
        cAlgo.API.Internals.MarketHours ToCAlgoMarketHours(IMarketHoursAdapter marketHoursAdapter);
        IMarketHours ToMarketHours(cAlgo.API.Internals.MarketHours cAlgoMarketHours);
    }
}