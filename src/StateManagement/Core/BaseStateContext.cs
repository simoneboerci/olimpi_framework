using System;
using System.Collections.Generic;
using StateManagement.Core.Interfaces;

namespace StateManagement.Core;

/// <summary>
/// Classe astratta che rappresenta un contesto di stato generico.
/// Permette di gestire proprietà dinamiche tramite una mappa chiave/valore.
/// </summary>
public abstract class BaseStateContext : IStateContext
{
    // Dizionario interno per memorizzare proprietà dinamiche associate al contesto.
    private readonly Dictionary<string, object> _properties = new();

    /// <summary>
    /// Imposta una proprietà nel contesto con una chiave specifica.
    /// </summary>
    /// <param name="key">Chiave della proprietà.</param>
    /// <param name="value">Valore della proprietà.</param>
    /// <exception cref="ArgumentException">Se la chiave è nulla o vuota.</exception>
    public void SetProperty(string key, object value)
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentException("Key cannot be null or whitespace.", nameof(key));
        }

        _properties[key] = value;
    }

    /// <summary>
    /// Ottiene una proprietà dal contesto e la converte al tipo specificato.
    /// </summary>
    /// <typeparam name="T">Tipo della proprietà attesa.</typeparam>
    /// <param name="key">Chiave della proprietà.</param>
    /// <returns>Valore della proprietà convertito al tipo T.</returns>
    /// <exception cref="KeyNotFoundException">Se la chiave non esiste.</exception>
    /// <exception cref="InvalidCastException">Se il valore non è del tipo richiesto.</exception>
    public T GetProperty<T>(string key)
    {
        if (_properties.TryGetValue(key, out object value))
        {
            if (value is T typedValue) return typedValue;
            throw new InvalidCastException($"Property '{key}' is not of type {typeof(T).Name}.");
        }

        throw new KeyNotFoundException($"Property '{key}' not found.");
    }

    /// <summary>
    /// Prova a ottenere una proprietà dal contesto e la converte al tipo specificato.
    /// </summary>
    /// <typeparam name="T">Tipo della proprietà attesa.</typeparam>
    /// <param name="key">Chiave della proprietà.</param>
    /// <param name="value">Valore della proprietà convertito al tipo T, oppure valore di default se non trovata.</param>
    /// <returns>True se la proprietà esiste ed è del tipo richiesto, altrimenti false.</returns>
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