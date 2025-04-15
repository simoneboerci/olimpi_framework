using cAlgo.API.Internals;
using CAlgoInterface.Core.Enums;
using CAlgoInterface.Core.Interfaces;
using CAlgoInterface.Core.Models;
using CAlgoInterface.Core.Routing;

namespace CAlgoInterface.Backend.Integrations;

public class SymbolAdapter : ISymbolAdapter
{
    private readonly Symbol _cAlgoSymbol;

    private readonly IAssetAdapter _assetAdapter;
    
    private readonly IRoundingModeMapper _roundingModeMapper;
    private readonly IProportionalAmountTypeMapper _proportionalAmountTypeMapper;
    private readonly ISymbolTradingModeMapper _symbolTradingModeMapper;
    private readonly ISymbolCommissionInfoMapper _symbolCommissionInfoMapper;
    private readonly IMarketHoursAdapter _marketHoursAdapter;

    public SymbolAdapter(Symbol cAlgoSymbol,
    IAssetAdapter assetAdapter,
    IRoundingModeMapper roundingModeMapper,
    IProportionalAmountTypeMapper proportionalAmountTypeMapper,
    ISymbolTradingModeMapper symbolTradingModeMapper,
    ISymbolCommissionInfoMapper symbolCommissionInfoMapper,
    IMarketHoursAdapter marketHoursAdapter
    )
    {
        _cAlgoSymbol = cAlgoSymbol;
        _roundingModeMapper = roundingModeMapper;
        _proportionalAmountTypeMapper = proportionalAmountTypeMapper;
        _assetAdapter = assetAdapter;
        _symbolTradingModeMapper = symbolTradingModeMapper;
        _symbolCommissionInfoMapper = symbolCommissionInfoMapper;
        _marketHoursAdapter = marketHoursAdapter;
    }

    public IAsset BaseAsset => _assetAdapter.ToAsset(_cAlgoSymbol.BaseAsset);
    public IAsset QuoteAsset => _assetAdapter.ToAsset(_cAlgoSymbol.QuoteAsset);

    public IMarketHours MarketHours => _marketHoursAdapter.ToMarketHours(_cAlgoSymbol.MarketHours);

    public double Ask => _cAlgoSymbol.Ask;
    public double Bid => _cAlgoSymbol.Bid;

    public double Spread => _cAlgoSymbol.Spread;

    public string Name => _cAlgoSymbol.Name;
    public string Description => _cAlgoSymbol.Description;

    public double TickValue => _cAlgoSymbol.TickValue;
    public double TickSize => _cAlgoSymbol.TickSize;

    public double PipValue => _cAlgoSymbol.PipValue;
    public double PipSize => _cAlgoSymbol.PipSize;

    public int Digits => _cAlgoSymbol.Digits;

    public bool IsTradingEnabled => _cAlgoSymbol.IsTradingEnabled;

    public SymbolVolumeInfo VolumeInfo
    {
        get
        {
            return new SymbolVolumeInfo(
                _cAlgoSymbol.VolumeInUnitsStep,
                _cAlgoSymbol.VolumeInUnitsMin,
                _cAlgoSymbol.VolumeInUnitsMax
            );
        }
    }

    public SymbolCommissionInfo CommissionInfo => _symbolCommissionInfoMapper.FromCAlgoSymbol(_cAlgoSymbol);

    public SymbolTradingMode TradingMode => _symbolTradingModeMapper.ToSymbolTradingMode(_cAlgoSymbol.TradingMode);

    public double MinTakeProfitDistance => _cAlgoSymbol.MinTakeProfitDistance;
    public double MinStopLossDistance => _cAlgoSymbol.MinStopLossDistance;

    public double PipsForFixedRisk(double amount, double volume) => _cAlgoSymbol.PipsForFixedRisk(amount, volume);
    public double PipsForProportionalRisk(ProportionalAmountType type, double percentage, double volume) => _cAlgoSymbol.PipsForProportionalRisk(_proportionalAmountTypeMapper.ToCAlgoProportionalAmountType(type), percentage, volume);

    public double VolumeForFixedRisk(double amount, double stopLossInPips) => _cAlgoSymbol.VolumeForFixedRisk(amount, stopLossInPips);
    public double VolumeForFixedRisk(double amount, double stopLossInPips, RoundingMode roundingMode) =>  _cAlgoSymbol.VolumeForFixedRisk(amount, stopLossInPips, _roundingModeMapper.ToCAlgoRoundingMode(roundingMode));

    public double VolumeForProportionalRisk(ProportionalAmountType type, double percentage, double stopLossInPips) => _cAlgoSymbol.VolumeForProportionalRisk(_proportionalAmountTypeMapper.ToCAlgoProportionalAmountType(type), percentage, stopLossInPips);
    public double VolumeForProportionalRisk(ProportionalAmountType type, double percentage, double stopLossInPips, RoundingMode roundingMode) => _cAlgoSymbol.VolumeForProportionalRisk(_proportionalAmountTypeMapper.ToCAlgoProportionalAmountType(type), percentage, stopLossInPips, _roundingModeMapper.ToCAlgoRoundingMode(roundingMode));

    public double QuantityToVolumeInUnits(double quantity) => _cAlgoSymbol.QuantityToVolumeInUnits(quantity);
    public double VolumeInUnitsToQuantity(double volume) => _cAlgoSymbol.VolumeInUnitsToQuantity(volume);
}