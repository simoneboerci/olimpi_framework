using CAlgoInterface.Backend.Routing;

namespace CAlgoInterface.Core.Routing;

public interface IOrderMapper<TCustomOrder, TCAlgoOrderStruct>
{
    TCAlgoOrderStruct Map(TCustomOrder customOrder);
}