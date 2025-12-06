#pragma warning disable CS0618 // Type or member is obsolete
using UnityEngine;

/// <summary>
/// Establece la posición inicial del jugador y puede resetear su posición guardada
/// </summary>
public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private Vector3 spawnPosition = Vector3.zero;
    [SerializeField] private bool useCurrentPositionAsSpawn = false;
    [SerializeField] private bool clearSavedPosition = true;
    [SerializeField] private string playerPositionSaverId = "Player"; // ID del PositionSaver del jugador
    
    private void Start()
    {
        SetPlayerSpawnPosition();
    }
    
    private void SetPlayerSpawnPosition()
    {
        // Si queremos usar la posición actual del objeto como spawn
        if (useCurrentPositionAsSpawn)
        {
            spawnPosition = transform.position;
        }
        
        // Buscar al jugador y establecer su posición
        if (Player.Instance != null)
        {
            Player.Instance.transform.position = spawnPosition;
            
            // Si queremos limpiar la posición guardada
            if (clearSavedPosition && !string.IsNullOrEmpty(playerPositionSaverId))
            {
                PlayerPrefs.DeleteKey(playerPositionSaverId + "X");
                PlayerPrefs.DeleteKey(playerPositionSaverId + "Y");
                PlayerPrefs.Save();
            }
        }
    }
    
    // Método público para establecer la posición desde otro script
    public void SetSpawnPosition(Vector3 newPosition)
    {
        spawnPosition = newPosition;
        SetPlayerSpawnPosition();
    }
    
    // Método para visualizar la posición de spawn en el editor
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(useCurrentPositionAsSpawn ? transform.position : spawnPosition, 0.5f);
        Gizmos.color = Color.yellow;
        Gizmos.DrawIcon(useCurrentPositionAsSpawn ? transform.position : spawnPosition, "sv_icon_dot3_pix16_gizmo", true);
    }
}