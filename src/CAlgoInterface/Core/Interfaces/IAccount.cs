using System;

namespace CAlgoInterface.Core.Interfaces;

public interface IAccount
{
    double Balance { get; }
    double Equity { get; }
    IAccountMargin Margin { get; }
    bool IsLive { get; }
    IAccountProfits Profits { get; }
    double Leverage { get; }
    double StopOutLevel { get; }
    IAsset Currency { get; }
    DateTime CreationTime {get;}
}