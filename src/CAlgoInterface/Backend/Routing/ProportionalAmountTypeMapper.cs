using CAlgoInterface.Core.Enums;
using CAlgoInterface.Core.Routing;

namespace CAlgoInterface.Backend.Routing;

public class ProportionalAmountTypeMapper : IProportionalAmountTypeMapper
{
    public cAlgo.API.ProportionalAmountType ToCAlgoProportionalAmountType(ProportionalAmountType type)
    {
        return type switch
        {
            ProportionalAmountType.Balance => cAlgo.API.ProportionalAmountType.Balance,
            ProportionalAmountType.Equity => cAlgo.API.ProportionalAmountType.Equity,
            _ => throw new System.NotImplementedException()
        };
    }

    public ProportionalAmountType ToProportionalAmountType(cAlgo.API.ProportionalAmountType cAlgoType)
    {
        return cAlgoType switch
        {
            cAlgo.API.ProportionalAmountType.Balance => ProportionalAmountType.Balance,
            cAlgo.API.ProportionalAmountType.Equity => ProportionalAmountType.Equity,
            _ => throw new System.NotImplementedException()
        };
    }
}