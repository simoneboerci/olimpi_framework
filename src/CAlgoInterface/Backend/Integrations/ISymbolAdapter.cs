using CAlgoInterface.Core.Interfaces;

namespace CAlgoInterface.Backend.Integrations;

public interface ISymbolAdapter : ISymbol, ICalculatePipsForRisk, ICalculateVolumeForRisk, IConvertVolumes
{

}