using System;
using cAlgo.API;

namespace CAlgoInterface.Core.Interfaces;

public interface IClosePositions
{
    #region Close Positions

    TradeResult ClosePosition(Position position);
    TradeResult ClosePosition(Position position, long volume);
    TradeResult ClosePosition(Position position, double volume);

    #endregion

    #region Close Positions Async

    TradeOperation ClosePositionAsync(Position position, Action<TradeResult> callback = null);
    TradeOperation ClosePositionAsync(Position position, long volume, Action<TradeResult> callback = null);
    TradeOperation ClosePositionAsync(Position position, double volume, Action<TradeResult> callback = null);

    #endregion
    
}