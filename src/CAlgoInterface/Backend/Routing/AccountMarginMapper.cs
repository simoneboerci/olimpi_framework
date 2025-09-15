using CAlgoInterface.Core.Interfaces;
using CAlgoInterface.Core.Models;
using CAlgoInterface.Core.Routing;

namespace CAlgoInterface.Backend.Routing;

public class AccountMarginMapper : IAccountMarginMapper
{
    public IAccountMargin FromCAlgoAccount(cAlgo.API.Internals.IAccount cAlgoAccount)
    {
        return new AccountMargin(
            cAlgoAccount.Margin,
            cAlgoAccount.FreeMargin,
            cAlgoAccount.MarginLevel
        );
    }
}