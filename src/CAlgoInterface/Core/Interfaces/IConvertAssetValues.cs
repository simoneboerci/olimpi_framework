using CAlgoInterface.Backend.Integrations;

namespace CAlgoInterface.Core.Interfaces;

public interface IConvertAssetValues
{
    double Convert(IAssetAdapter to, double value);
    double Convert(string to, double value);
}