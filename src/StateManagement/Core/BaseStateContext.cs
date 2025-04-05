using System;
using System.Collections.Generic;
using StateManagement.Core.Interfaces;

namespace StateManagement.Core;

public abstract class BaseStateContext : IStateContext
{
    private readonly Dictionary<string, object> _properties = new();

    public void SetProperty(string key, object value)
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentException("Key cannot be null or whitespace.", nameof(key));
        }

        _properties[key] = value;
    }

    public T GetProperty<T>(string key)
    {
        if (_properties.TryGetValue(key, out object value))
        {
            if (value is T typedValue) return typedValue;
            throw new InvalidCastException($"Property '{key}' is not of type {typeof(T).Name}.");
        }

        throw new KeyNotFoundException($"Property '{key}' not found.");
    }

    public bool TryGetProperty<T>(string key, out T value)
    {
        if (_properties.TryGetValue(key, out object objValue) && objValue is T typedValue)
        {
            value = typedValue;
            return true;
        }

        value = default;
        return false;
    }
}