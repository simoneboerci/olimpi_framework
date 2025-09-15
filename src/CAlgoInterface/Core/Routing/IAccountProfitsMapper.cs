using CAlgoInterface.Core.Interfaces;

namespace CAlgoInterface.Core.Routing;

public interface IAccountProfitsMapper
{
    IAccountProfits FromCAlgoAccount(cAlgo.API.Internals.IAccount cAlgoAccount);
}