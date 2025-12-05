using UnityEngine;

public class MapZonesManager : MonoBehaviour
{
    public void Start()
    {
        string username = DataManagerComposer.CurrentUsername;
        int playerLevel = DataManagerComposer.GetPlayerLevel(username);
        
        Debug.Log($"[MapZonesManager] Usuario: {username}, Nivel del jugador: {playerLevel}");

        MapSelectZone[] levels = GetComponentsInChildren<MapSelectZone>();
        Debug.Log($"[MapZonesManager] Encontrados {levels.Length} niveles para desbloquear");

        // Desbloquear niveles desde 0 hasta el nivel del jugador
        for (int i = 0; i < levels.Length && i <= playerLevel; i++)
        {
            if (levels[i] != null)
            {
                levels[i].IsLocked = false;
                Debug.Log($"[MapZonesManager] Desbloqueado nivel {i + 1}");
            }
        }
        
        // Asegurar que siempre esté desbloqueado al menos el nivel 1
        if (levels.Length > 0 && levels[0] != null)
        {
            levels[0].IsLocked = false;
        }
    }
}
