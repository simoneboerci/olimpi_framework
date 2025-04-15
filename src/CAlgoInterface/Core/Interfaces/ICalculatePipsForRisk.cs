using CAlgoInterface.Core.Enums;

namespace CAlgoInterface.Core.Interfaces;

public interface ICalculatePipsForRisk
{
    double PipsForFixedRisk(double amount, double volume);
    double PipsForProportionalRisk(ProportionalAmountType type, double percentage, double volume);
}