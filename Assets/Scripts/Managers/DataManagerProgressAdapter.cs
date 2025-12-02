using UnityEngine;

/// <summary>
/// Adaptador para usar DataManagerComposer como sistema de persistencia
/// Patrón: Adapter Pattern
/// Principio: Single Responsibility Principle (SRP)
/// </summary>
public class DataManagerProgressAdapter : IProgressPersistence
{
    public void SaveLevelCompletion(int levelNumber)
    {
        string username = DataManagerComposer.CurrentUsername;
        int currentPlayerLevel = DataManagerComposer.GetPlayerLevel(username);
        
        Debug.Log($"[DataManagerProgressAdapter] === GUARDANDO PROGRESO ===");
        Debug.Log($"[DataManagerProgressAdapter] Usuario: {username}");
        Debug.Log($"[DataManagerProgressAdapter] Nivel completado: {levelNumber}");
        Debug.Log($"[DataManagerProgressAdapter] Nivel actual del jugador: {currentPlayerLevel}");
        
        // Al completar Level1, el jugador debería llegar a nivel 1
        // Al completar Level2, el jugador debería llegar a nivel 2, etc.
        int newPlayerLevel = levelNumber;
        
        // Siempre guardar el progreso (incluso si es el mismo nivel)
        DataManagerComposer.SavePlayerLevel(username, newPlayerLevel);
        Debug.Log($"[DataManagerProgressAdapter] ¡NIVEL GUARDADO! Nuevo nivel del jugador: {newPlayerLevel}");
        
        // Verificar que se guardó correctamente
        int verifyLevel = DataManagerComposer.GetPlayerLevel(username);
        Debug.Log($"[DataManagerProgressAdapter] Verificación - Nivel leído: {verifyLevel}");
        Debug.Log($"[DataManagerProgressAdapter] === FIN GUARDADO ===");
    }
    
    public int GetPlayerLevel(string username)
    {
        return DataManagerComposer.GetPlayerLevel(username);
    }
}