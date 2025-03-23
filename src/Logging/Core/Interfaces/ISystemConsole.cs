using System;

namespace Logging.Core.Interfaces;

public interface ISystemConsole : IDisposable
{
    void Start();
    void WriteLine(string text);
}