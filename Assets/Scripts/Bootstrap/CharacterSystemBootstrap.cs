using UnityEngine;

/// <summary>
/// Bootstrap automático para CharacterSystemComposer
/// Asegura que el sistema esté disponible antes de que cualquier personaje lo necesite
/// Ejecuta antes que todos los otros scripts (-100)
/// </summary>
[DefaultExecutionOrder(-100)]
public class CharacterSystemBootstrap : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        // Verificar si ya existe
        if (CharacterSystemComposer.Instance == null)
        {
            GameObject composerObj = new GameObject("[CharacterSystemComposer]");
            composerObj.AddComponent<CharacterSystemComposer>();
            DontDestroyOnLoad(composerObj);
            
            Debug.Log("[CharacterSystemBootstrap] ✅ CharacterSystemComposer creado automáticamente");
        }
    }
}
