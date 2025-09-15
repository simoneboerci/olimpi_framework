using CAlgoInterface.Core.Interfaces;

namespace CAlgoInterface.Core.Models;

public readonly struct AccountMargin : IAccountMargin
{
    public double TotalMargin { get; }
    public double FreeMargin { get; }
    public double? MarginLevel { get; }

    public AccountMargin(
        double totalMargin,
        double freeMargin,
        double? marginLevel
    )
    {
        TotalMargin = totalMargin;
        FreeMargin = freeMargin;
        MarginLevel = marginLevel;
    }
}