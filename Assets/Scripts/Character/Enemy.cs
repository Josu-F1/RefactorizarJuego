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
[RequireComponent(typeof(global::Health))]
public class Enemy : MonoBehaviour, ICharacter
{
    [SerializeField] private int score = 5;
    public static Action<int> OnAnyEnemyKilled { get; set; }
    public CharacterType CharacterType => CharacterType.Enemy;
    
    // [REMOVED] private Health health; - Migrated to CharacterSystemComposer
    private ICharacterController characterController;
    private CharacterSystemComposer characterSystemComposer;
    
    private void Awake()
    {
        // [REMOVED] health = GetComponent<Health>(); - Migrated to CharacterSystemComposer
    }
    
    private void Start()
    {
        // Obtener el sistema refactorizado (en Start para garantizar inicialización)
        characterSystemComposer = CharacterSystemComposer.Instance;
        
        // Si no existe, crearlo automáticamente
        if (characterSystemComposer == null)
        {
            Debug.LogWarning("[Enemy] CharacterSystemComposer no encontrado - Creando automáticamente...");
            GameObject composerObj = new GameObject("CharacterSystemComposer");
            characterSystemComposer = composerObj.AddComponent<CharacterSystemComposer>();
        }
        
        // Crear configuración personalizada con el score de este enemigo
        var customConfig = new CharacterConfig
        {
            characterType = CharacterType.Enemy,
            providesScore = true,
            scoreValue = score,
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
            Debug.Log("[Enemy] ✅ Usando CharacterSystemComposer (Clean Architecture)");
        }
    }
    
    private void OnDestroy()
    {
        // Limpiar CharacterSystemComposer
        if (characterSystemComposer != null && gameObject != null)
        {
            characterSystemComposer.CleanupController(gameObject);
        }
    }
}
