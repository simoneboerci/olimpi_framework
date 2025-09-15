using CAlgoInterface.Core.Interfaces;

namespace CAlgoInterface.Core.Routing;

public interface IAccountMarginMapper
{
    IAccountMargin FromCAlgoAccount(cAlgo.API.Internals.IAccount cAlgoAccount);
}