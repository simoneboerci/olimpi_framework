namespace CAlgoInterface.Backend.Services;

public interface ICTraderConsole
{
    void Log(object value);
    void Log(params object[] parameters);
    void Log(string message, params object[] parameters);
}