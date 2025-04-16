using System;
using cAlgo.API;
using CAlgoInterface.Core.Interfaces;

namespace CAlgoInterface.Application;

public interface ICAlgoPositionManager : ICancelPendingOrders, IReversePositions, IClosePositions, IModifyPositions, IModifyPendingOrders
{
        
}