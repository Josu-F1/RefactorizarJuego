#pragma warning disable CS0618 // Type or member is obsolete
using UnityEngine;

/// <summary>
/// Se encarga de inicializar correctamente el nivel al empezar
/// </summary>
public class LevelInitializer : MonoBehaviour
{
    [SerializeField] private bool resetTimeScale = true;
    [SerializeField] private bool resetPlayerPosition = true;
    [SerializeField] private Vector3 playerSpawnPosition = new Vector3(0, 0, 0);
    
    private void Awake()
    {
        // Asegurar que el tiempo esté correcto al inicio
        if (resetTimeScale)
        {
            Time.timeScale = 1f;
        }
    }
    
    private void Start()
    {
        // Resetear la posición del jugador si es necesario
        if (resetPlayerPosition && Player.Instance != null)
        {
            Player.Instance.transform.position = playerSpawnPosition;
        }
    }
}