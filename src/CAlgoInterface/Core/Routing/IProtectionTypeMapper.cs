using CAlgoInterface.Core.Enums;

namespace CAlgoInterface.Core.Routing;

public interface IProtectionTypeMapper
{
    cAlgo.API.ProtectionType ToCAlgoProtectionType(ProtectionType protectionType);
    ProtectionType ToProtectionType(cAlgo.API.ProtectionType cAlgoProtectionType);
}