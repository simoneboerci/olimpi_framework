namespace CAlgoInterface.Core.Interfaces;

public interface IAccountMargin
{
    double TotalMargin { get; }
    double FreeMargin { get; }
    double? MarginLevel { get; }
}