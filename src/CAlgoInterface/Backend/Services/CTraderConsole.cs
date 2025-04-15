using cAlgo.API.Internals;

namespace CAlgoInterface.Backend.Services;

public class CTraderConsole : ICTraderConsole
{
    private readonly Algo _algo;

    public CTraderConsole(Algo algo) => _algo = algo;

    public void Log(object value) => _algo.Print(value);
    public void Log(params object[] parameters) => _algo.Print(parameters);
    public void Log(string message, params object[] parameters) => _algo.Print(message, parameters);
}