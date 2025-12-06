#pragma warning disable CS0618 // Type or member is obsolete
using UnityEngine;
using System.Collections;

/// <summary>
/// Establece la posición inicial del jugador y puede resetear su posición guardada
/// </summary>
public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private Vector3 spawnPosition = Vector3.zero;
    [SerializeField] private bool useCurrentPositionAsSpawn = false;
    [SerializeField] private bool clearSavedPosition = true;
    [SerializeField] private string playerPositionSaverId = "Player"; // ID del PositionSaver del jugador
    
    private Coroutine spawnRoutine;

    private void Start()
    {
        spawnRoutine = StartCoroutine(WaitForPlayerAndSpawn());
    }

    private IEnumerator WaitForPlayerAndSpawn()
    {
        if (useCurrentPositionAsSpawn)
        {
            spawnPosition = transform.position;
        }

        while (Player.Instance == null)
        {
            yield return null;
        }

        ApplySpawnPosition();
    }

    private void ApplySpawnPosition()
    {
        var player = Player.Instance;
        if (player == null)
        {
            return;
        }

        player.transform.position = spawnPosition;

        if (clearSavedPosition && !string.IsNullOrEmpty(playerPositionSaverId))
        {
            PlayerPrefs.DeleteKey(playerPositionSaverId + "X");
            PlayerPrefs.DeleteKey(playerPositionSaverId + "Y");
            PlayerPrefs.Save();
        }
    }
    
    // Método público para establecer la posición desde otro script
    public void SetSpawnPosition(Vector3 newPosition)
    {
        spawnPosition = newPosition;
        ApplySpawnPosition();
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