namespace StateManagement.Core.Interfaces
{
    /// <summary>
    /// Interfaccia che rappresenta il contesto di uno stato.
    /// Permette di gestire proprietà condivise tra stati tramite chiavi stringa.
    /// </summary>
    public interface IStateContext
    {
        /// <summary>
        /// Imposta una proprietà nel contesto con la chiave specificata.
        /// </summary>
        /// <param name="key">Chiave della proprietà.</param>
        /// <param name="value">Valore da associare alla chiave.</param>
        void SetProperty(string key, object value);

        /// <summary>
        /// Ottiene una proprietà dal contesto, convertendola al tipo specificato.
        /// </summary>
        /// <typeparam name="T">Tipo della proprietà da restituire.</typeparam>
        /// <param name="key">Chiave della proprietà.</param>
        /// <returns>Valore della proprietà convertito al tipo T.</returns>
        T GetProperty<T>(string key);

        /// <summary>
        /// Prova a ottenere una proprietà dal contesto, restituendo true se la chiave esiste.
        /// </summary>
        /// <typeparam name="T">Tipo della proprietà da restituire.</typeparam>
        /// <param name="key">Chiave della proprietà.</param>
        /// <param name="value">Valore della proprietà se trovato, altrimenti valore di default.</param>
        /// <returns>True se la proprietà esiste, altrimenti false.</returns>
        bool TryGetProperty<T>(string key, out T value);
    }
}