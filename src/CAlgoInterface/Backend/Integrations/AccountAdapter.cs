using System;
using CAlgoInterface.Core.Routing;
using CAlgoInterface.Core.Interfaces;

namespace CAlgoInterface.Backend.Integrations;

public class AccountAdapter : IAccountAdapter
{
    private readonly cAlgo.API.Internals.IAccount _cAlgoAccount;

    private readonly IAssetAdapter _assetAdapter;
    private readonly IAccountMarginMapper _accountMarginMapper;
    private readonly IAccountProfitsMapper _accountProfitsMapper;

    public AccountAdapter(
        cAlgo.API.Internals.IAccount cAlgoAccount,
        IAssetAdapter assetAdapter,
        IAccountMarginMapper accountMarginMapper,
        IAccountProfitsMapper accountProfitsMapper
    )
    {
        _cAlgoAccount = cAlgoAccount;
        _assetAdapter = assetAdapter;
        _accountMarginMapper = accountMarginMapper;
        _accountProfitsMapper = accountProfitsMapper;
    } 

    public double Balance => _cAlgoAccount.Balance;
    public double Equity => _cAlgoAccount.Equity;
    public IAccountMargin Margin => _accountMarginMapper.FromCAlgoAccount(_cAlgoAccount);
    public bool IsLive => _cAlgoAccount.IsLive;
    public IAccountProfits Profits => _accountProfitsMapper.FromCAlgoAccount(_cAlgoAccount);
    public double Leverage => _cAlgoAccount.PreciseLeverage;
    public double StopOutLevel => _cAlgoAccount.StopOutLevel;
    public IAsset Currency => _assetAdapter.ToAsset(_cAlgoAccount.Asset);
    public DateTime CreationTime => _cAlgoAccount.CreationTime;

    public cAlgo.API.Internals.IAccount GetCAlgoAccount() => _cAlgoAccount;
}