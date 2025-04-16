using System;
using cAlgo.API;

namespace CAlgoInterface.Core.Interfaces;

public interface IReversePositions
{
    #region Reverse Positions

    TradeResult ReversePosition(Position position);
    TradeResult ReversePosition(Position position, double volume);

    #endregion

    #region Reverse Positions Async
    
    TradeOperation ReversePositionAsync(Position position, Action<TradeResult> callback = null);
    TradeOperation ReversePositionAsync(Position position, double volume, Action<TradeResult> callback = null);

    #endregion
}