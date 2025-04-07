using CAlgoInterface.Core.Interfaces;

namespace CAlgoInterface.Backend.Integrations;

public interface IAssetAdapter : IAsset, IConvertAssets, IConvertAssetValues
{
    cAlgo.API.Asset CAlgoAsset();
}