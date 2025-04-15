using CAlgoInterface.Backend.Integrations;

namespace CAlgoInterface.Core.Interfaces;

public interface IConvertAssets
{
    cAlgo.API.Asset ToCAlgoAsset(IAssetAdapter assetAdapter);
    IAsset ToAsset(cAlgo.API.Asset cAlgoAsset);
}