using CAlgoInterface.Core.Interfaces;

namespace CAlgoInterface.Backend.Integrations;

public interface IAccountAdapter : IAccount
{
    cAlgo.API.Internals.IAccount GetCAlgoAccount();
}