namespace OrderExecution.Core.Interfaces;

public interface IActivePosition : IPosition
{
    double GrossProfit { get; }
    double NetProfit { get; }

    double Swap { get; }
    double Commissions { get; }

    double CurrentPrice { get; }
    double MarginUsed { get; }
}