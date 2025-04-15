using CAlgoInterface.Core.Enums;

namespace CAlgoInterface.Core.Interfaces;

public interface INormalizeVolumes
{
    double NormalizeVolumeInUnits(double volume);
    double NormalizeVolumeInUnits(double volume, RoundingMode roundingMode);
}