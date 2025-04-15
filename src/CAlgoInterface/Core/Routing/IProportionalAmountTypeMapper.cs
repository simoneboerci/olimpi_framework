using CAlgoInterface.Core.Enums;

namespace CAlgoInterface.Core.Routing;

public interface IProportionalAmountTypeMapper
{
    cAlgo.API.ProportionalAmountType ToCAlgoProportionalAmountType(ProportionalAmountType type);
    ProportionalAmountType ToProportionalAmountType(cAlgo.API.ProportionalAmountType type);
}