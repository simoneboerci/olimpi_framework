using CAlgoInterface.Core.Enums;

namespace CAlgoInterface.Core.Interfaces;

public interface ICalculateVolumeForRisk
{
    double VolumeForFixedRisk(double amount, double stopLossInPips);
    double VolumeForFixedRisk(double amount, double stopLossInPips, RoundingMode roundingMode);

    double VolumeForProportionalRisk(ProportionalAmountType type, double percentage, double stopLossInPips);
    double VolumeForProportionalRisk(ProportionalAmountType type, double percentage, double stopLossInPips, RoundingMode roundingMode);
}