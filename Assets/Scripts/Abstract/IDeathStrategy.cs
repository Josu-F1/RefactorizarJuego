/// <summary>
/// Interface para estrategias de muerte
/// Patrón: Strategy Pattern - Diferentes comportamientos al morir
/// </summary>
public interface IDeathStrategy
{
    void OnDeath(UnityEngine.GameObject character);
}