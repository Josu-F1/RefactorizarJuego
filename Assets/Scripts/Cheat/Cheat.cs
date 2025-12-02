using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// OBSOLETO: Usar CheatSystemComposer en su lugar
/// Refactorizado aplicando Command Pattern y principios SOLID
/// Migrar a: CheatSystemComposer que incluye sistema refactorizado
/// Fecha: Diciembre 2024
/// Razón: Violación de SRP, acoplamiento fuerte con Health, falta de extensibilidad
/// </summary>
[System.Obsolete("Use CheatSystemComposer instead - Refactored with Command Pattern and SOLID principles", false)]
public class Cheat : MonoBehaviour
{
    private const float veryLargeNumber = 100000;
    
    // Sistema de compatibilidad hacia atrás
    private static CharacterSystemComposer characterSystemComposer;
    
    static Cheat()
    {
        // Intentar obtener el sistema refactorizado
        if (Application.isPlaying)
        {
            characterSystemComposer = CharacterSystemComposer.Instance;
        }
    }
    
    /// <summary>
    /// OBSOLETO: Usar CheatSystemComposer.ExecuteKillAllEnemies() en su lugar
    /// </summary>
    [System.Obsolete("Use CheatSystemComposer.ExecuteKillAllEnemies() instead", false)]
    public static void KillAllEnemies()
    {
        // Intentar usar el sistema refactorizado primero
        if (characterSystemComposer != null)
        {
            characterSystemComposer.ExecuteEnemyKillCheat();
            Debug.Log("[Cheat] Usando CharacterSystemComposer (SOLID refactorizado)");
        }
        else
        {
            // Fallback al sistema legacy
            Debug.LogWarning("[Cheat] OBSOLETO: Usando implementación legacy. Migrar a CheatSystemComposer.");
            Enemy[] enemies = FindObjectsOfType<Enemy>();
            foreach (var enemy in enemies)
            {
                var health = enemy.GetComponent<Health>();
                if (health != null)
                {
                    health.TakeDamage(veryLargeNumber);
                }
            }
        }
    }
    
    /// <summary>
    /// OBSOLETO: Usar CheatSystemComposer.ExecuteHealPlayer() en su lugar
    /// </summary>
    [System.Obsolete("Use CheatSystemComposer.ExecuteHealPlayer() instead", false)]
    public static void Heal()
    {
        // Intentar usar el sistema refactorizado primero
        if (characterSystemComposer != null)
        {
            characterSystemComposer.ExecutePlayerHealCheat();
            Debug.Log("[Cheat] Usando CharacterSystemComposer (SOLID refactorizado)");
        }
        else
        {
            // Fallback al sistema legacy
            Debug.LogWarning("[Cheat] OBSOLETO: Usando implementación legacy. Migrar a CheatSystemComposer.");
            if (Player.Instance != null)
            {
                var health = Player.Instance.GetComponent<Health>();
                if (health != null)
                {
                    health.Heal(veryLargeNumber);
                }
            }
        }
    }
}
