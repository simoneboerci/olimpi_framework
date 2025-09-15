using CAlgoInterface.Core.Interfaces;

namespace CAlgoInterface.Core.Models;

public readonly struct AccountProfits : IAccountProfits
{
    public double UnrealizedGrossProfit { get; }
    public double UnrealizedNetProfit { get; }

    public AccountProfits(
        double unrealizedGrossProfit,
        double unrealizedNetProfit
    )
    {
        UnrealizedGrossProfit = unrealizedGrossProfit;
        UnrealizedNetProfit = unrealizedNetProfit;
    }
}