using System;
using UnityEngine;

/// <summary>
/// OBSOLETO: Usar CharacterSystemComposer en su lugar
/// Refactorizado aplicando Component Pattern y principios SOLID
/// Migrar a: CharacterSystemComposer con CharacterController y ScoreProvider component
/// Fecha: Diciembre 2024
/// Razón: Violación SRP (muerte + score), acoplamiento fuerte, falta de configurabilidad
/// </summary>
[System.Obsolete("Use CharacterSystemComposer with CharacterController instead - Refactored with Component Pattern", false)]
[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour, ICharacter
{
    [SerializeField] private int score = 5;
    public static Action<int> OnAnyEnemyKilled { get; set; }
    public CharacterType CharacterType => CharacterType.Enemy;
    
    private Health health;
    private ICharacterController characterController;
    private CharacterSystemComposer characterSystemComposer;
    
    private void Awake()
    {
        health = GetComponent<Health>();
        
        // Intentar obtener el sistema refactorizado
        characterSystemComposer = CharacterSystemComposer.Instance;
    }
    
    private void Start()
    {
        // Si existe el sistema refactorizado, crear configuración personalizada
        if (characterSystemComposer != null)
        {
            // Crear configuración personalizada con el score de este enemigo
            var customConfig = new CharacterConfig
            {
                characterType = CharacterType.Enemy,
                providesScore = true,
                scoreValue = score, // Usar el score configurado en Inspector
                deathBehavior = DeathBehaviorType.Destroy,
                deathDelay = 0f,
                notifyGlobalEvents = true
            };
            
            characterController = characterSystemComposer.GetController(gameObject);
            if (characterController == null)
            {
                // Crear controller con configuración personalizada
                var factory = new CharacterControllerFactory();
                characterController = factory.CreateCharacterController(CharacterType.Enemy, gameObject, customConfig);
                Debug.Log("[Enemy] Usando CharacterSystemComposer (SOLID refactorizado)");
            }
        }
        else
        {
            // Sistema legacy
            Debug.LogWarning("[Enemy] OBSOLETO: Usando implementación legacy. Migrar a CharacterSystemComposer.");
            health.OnDead += Die;
        }
    }
    
    private void Die()
    {
        OnAnyEnemyKilled?.Invoke(score);
        Destroy(gameObject);
    }
    
    private void OnDestroy()
    {
        // Limpiar el controlador si existe
        if (characterSystemComposer != null && gameObject != null)
        {
            characterSystemComposer.CleanupController(gameObject);
        }
        
        // Sistema legacy cleanup
        if (health != null)
        {
            health.OnDead -= Die;
        }
    }
}
