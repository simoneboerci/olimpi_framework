using System;
using OrderCreation;
using OrderCreation.Core.Enums;
using OrderExecution.Core.Interfaces;

namespace OrderExecution.Application;

public interface IPositionManager :
ICancelPendingPositions,
IModifyPendingPositions,
IReversePositions,
IModifyPositions,
IClosePositions
{
    
}