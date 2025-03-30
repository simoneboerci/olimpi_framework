namespace StateManagement.Core.Interfaces;

public interface IStateContext
{   
    void SetProperty(string key, object value);
    T GetProperty<T>(string key);
    bool TryGetProperty<T>(string key, out T value);
}