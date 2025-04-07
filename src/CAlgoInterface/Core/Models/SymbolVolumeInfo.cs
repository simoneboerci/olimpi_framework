namespace CAlgoInterface.Core.Models;

public readonly struct SymbolVolumeInfo
{
    double VolumeInUnitsStep { get; }
    double VolumeInUnitsMin { get; }
    double VolumeInUnitsMax { get; }

    public SymbolVolumeInfo
    (
        double volumeInUnitsStep,
        double volumeInUnitsMin,
        double volumeInUnitsMax
    )
    {
        VolumeInUnitsStep = volumeInUnitsStep;
        VolumeInUnitsMin = volumeInUnitsMin;
        VolumeInUnitsMax = volumeInUnitsMax;
    }
}