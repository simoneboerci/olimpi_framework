namespace CAlgoInterface.Core.Interfaces;

public interface IConvertVolumes
{
    double QuantityToVolumeInUnits(double quantity);
    double VolumeInUnitsToQuantity(double volume);
}