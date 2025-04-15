using CAlgoInterface.Core.Enums;

namespace CAlgoInterface.Core.Routing;

public interface IRoundingModeMapper
{
    cAlgo.API.RoundingMode ToCAlgoRoundingMode(RoundingMode roundingMode);
    RoundingMode ToRoundingMode(cAlgo.API.RoundingMode cAlgoRoundingMode);
}