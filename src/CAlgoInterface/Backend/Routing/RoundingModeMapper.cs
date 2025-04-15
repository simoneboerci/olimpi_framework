using CAlgoInterface.Core.Enums;
using CAlgoInterface.Core.Routing;

namespace CAlgoInterface.Backend.Routing;

public class RoundingModeMapper : IRoundingModeMapper
{
    public cAlgo.API.RoundingMode ToCAlgoRoundingMode(RoundingMode roundingMode)
    {
        return roundingMode switch
        {
            RoundingMode.ToNearest => cAlgo.API.RoundingMode.ToNearest,
            RoundingMode.Down => cAlgo.API.RoundingMode.Down,
            RoundingMode.Up => cAlgo.API.RoundingMode.Up,
            _ => throw new System.ArgumentOutOfRangeException(nameof(roundingMode), roundingMode, null),
        };
    }

    public RoundingMode ToRoundingMode(cAlgo.API.RoundingMode cAlgoRoundingMode)
    {
        return cAlgoRoundingMode switch
        {
            cAlgo.API.RoundingMode.ToNearest => RoundingMode.ToNearest,
            cAlgo.API.RoundingMode.Down => RoundingMode.Down,
            cAlgo.API.RoundingMode.Up => RoundingMode.Up,
            _ => throw new System.ArgumentOutOfRangeException(nameof(cAlgoRoundingMode), cAlgoRoundingMode, null),
        };
    }
}