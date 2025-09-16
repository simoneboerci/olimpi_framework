namespace CAlgoInterface.Core.Interfaces;

/// <summary>
/// Interfaccia che rappresenta una posizione pendente di trading.
/// Estende <see cref="IPosition"/> e può essere implementata per aggiungere proprietà o metodi specifici delle posizioni non ancora attive.
/// </summary>
public interface IPendingPosition : IPosition
{
    
}