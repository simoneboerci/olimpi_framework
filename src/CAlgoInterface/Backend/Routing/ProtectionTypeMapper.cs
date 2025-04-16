using CAlgoInterface.Core.Routing;
using OrderCreation.Core.Enums;

namespace CAlgoInterface.Backend.Routing;

public class ProtectionTypeMapper : IProtectionTypeMapper
{
    public cAlgo.API.ProtectionType ToCAlgoProtectionType(ProtectionType protectionType)
    {
        return protectionType switch
        {
            ProtectionType.None => cAlgo.API.ProtectionType.None,
            ProtectionType.Absolute => cAlgo.API.ProtectionType.Absolute,
            ProtectionType.Relative => cAlgo.API.ProtectionType.Relative,
            _ => throw new System.NotImplementedException()
        };
    }

    public ProtectionType ToProtectionType(cAlgo.API.ProtectionType cAlgoProtectionType)
    {
        return cAlgoProtectionType switch
        {
            cAlgo.API.ProtectionType.None => ProtectionType.None,
            cAlgo.API.ProtectionType.Absolute => ProtectionType.Absolute,
            cAlgo.API.ProtectionType.Relative => ProtectionType.Relative,
            _ => throw new System.NotImplementedException()
        };
    }
}