using System;

namespace Logging.Core.Interfaces;

/// <summary>
/// Interfaccia che rappresenta un sistema console per la gestione dell'output e delle risorse della console.
/// Fornisce metodi per l'avvio del sistema console e per la scrittura di messaggi.
/// Implementa IDisposable per permettere il rilascio corretto delle risorse associate.
/// </summary>
public interface ISystemConsole : IDisposable
{
    /// <summary>
    /// Avvia il sistema console, eseguendo eventuali inizializzazioni necessarie.
    /// </summary>
    void Start();

    /// <summary>
    /// Scrive una riga di testo sulla console.
    /// </summary>
    /// <param name="text">Il testo da scrivere sulla console.</param>
    void WriteLine(string text);
}