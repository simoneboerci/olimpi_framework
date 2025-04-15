using CAlgoInterface.Core.Interfaces;

namespace CAlgoInterface.Backend.Integrations;

public class AssetAdapter : IAssetAdapter
{
    private readonly cAlgo.API.Asset _cAlgoAsset;

    public AssetAdapter(cAlgo.API.Asset cAlgoAsset) => _cAlgoAsset = cAlgoAsset;

    public cAlgo.API.Asset GetCAlgoAsset() => _cAlgoAsset;

    public string Name => _cAlgoAsset.Name;
    public int Digits => _cAlgoAsset.Digits;

    public IAsset ToAsset(cAlgo.API.Asset cAlgoAsset) => new AssetAdapter(cAlgoAsset);
    public cAlgo.API.Asset ToCAlgoAsset(IAssetAdapter asset) => asset.GetCAlgoAsset();
    
    public double Convert(IAssetAdapter to, double value) => _cAlgoAsset.Convert(ToCAlgoAsset(to), value);
    public double Convert(string to, double value) => _cAlgoAsset.Convert(to, value);
}