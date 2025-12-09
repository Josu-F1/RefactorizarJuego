#pragma warning disable CS0618 // Type or member is obsolete
using UnityEngine;

/// <summary>
/// Asegura que el juego esté en modo jugable al iniciar la escena
/// Fuerza Time.timeScale = 1 y verifica sistemas críticos
/// </summary>
public class GameplayEnsurer : MonoBehaviour
{
    [Header("Verificación")]
    [SerializeField] private bool enforceTimeScale = true;
    [SerializeField] private bool checkLevelProgressTracker = true;
    
    private void Awake()
    {
        // Asegurar que el juego NO esté pausado
        if (enforceTimeScale)
        {
            Time.timeScale = 1f;
            Debug.Log("[GameplayEnsurer] ✅ Time.timeScale establecido a 1 (juego activo)");
        }
    }
    
    private void Start()
    {
        // Verificar que LevelProgressTracker esté presente
        if (checkLevelProgressTracker)
        {
            var tracker = FindObjectOfType<LevelProgressTracker>();
            if (tracker == null)
            {
                Debug.LogWarning("[GameplayEnsurer] ⚠️ No se encontró LevelProgressTracker. El progreso del nivel no se guardará.");
            }
            else
            {
                Debug.Log("[GameplayEnsurer] ✅ LevelProgressTracker encontrado y activo");
            }
        }
        
        // Verificar que haya enemigos
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Debug.Log($"[GameplayEnsurer] 🎯 Enemigos en la escena: {enemies.Length}");
        
        // Verificar que haya jugador
        Player player = FindObjectOfType<Player>();
        if (player != null)
        {
            Debug.Log($"[GameplayEnsurer] ✅ Jugador encontrado: {player.name}");
            
            // Verificar CharacterSystemComposer (Clean Architecture)
            CharacterSystemComposer characterSystem = FindObjectOfType<CharacterSystemComposer>();
            if (characterSystem != null)
            {
                Debug.Log("[GameplayEnsurer] ✅ CharacterSystemComposer activo (Clean Architecture)");
            }
            else
            {
                Debug.LogError("[GameplayEnsurer] ❌ CharacterSystemComposer no encontrado!");
            }
        }
        else
        {
            Debug.LogError("[GameplayEnsurer] ❌ No se encontró jugador en la escena!");
        }
    }
}
