using CAlgoInterface.Core.Enums;
using CAlgoInterface.Core.Models;

namespace CAlgoInterface.Core.Interfaces
{
    public interface ISymbol
    {
        IAsset BaseAsset { get; }
        IAsset QuoteAsset { get; }

        double Ask { get; }
        double Bid{ get; }
        double Spread{ get; }

        IMarketHours MarketHours { get; }

        string Name { get; }
        string Description { get; }
        double TickValue { get; }
        double TickSize { get; }
        double PipValue { get; }
        double PipSize { get; }
        int Digits { get; }

        SymbolVolumeInfo VolumeInfo { get; }
        SymbolCommissionInfo CommissionInfo { get; }

        bool IsTradingEnabled { get; }
        SymbolTradingMode TradingMode { get; }
        double MinTakeProfitDistance { get; }
        double MinStopLossDistance { get; }
    }
}