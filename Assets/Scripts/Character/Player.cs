using UnityEngine;
using System;

/// <summary>
/// OBSOLETO: Usar CharacterSystemComposer en su lugar
/// Refactorizado aplicando Component Pattern y principios SOLID
/// Migrar a: CharacterSystemComposer con CharacterController y componentes modulares
/// Fecha: Diciembre 2024
/// Razón: Violación SRP, lógica mezclada, falta de extensibilidad
/// </summary>
[System.Obsolete("Use CharacterSystemComposer with CharacterController instead - Refactored with Component Pattern", false)]
[RequireComponent(typeof(global::Health))]
public class Player : MonoBehaviourSingleton<Player>, ICharacter
{
    public CharacterType CharacterType => CharacterType.Player;
    public Action OnPlayerDead { get; set; }
    
    // [REMOVED] private Health health; - Migrated to CharacterSystemComposer
    private ICharacterController characterController;
    private CharacterSystemComposer characterSystemComposer;
    
    protected override void Awake()
    {
        base.Awake();
        // [REMOVED] health = GetComponent<Health>(); - Migrated to CharacterSystemComposer
    }
    
    private void Start()
    {
        // Obtener el sistema refactorizado (en Start para garantizar inicialización)
        characterSystemComposer = CharacterSystemComposer.Instance;
        
        // Si no existe, crearlo automáticamente
        if (characterSystemComposer == null)
        {
            Debug.LogWarning("[Player] CharacterSystemComposer no encontrado - Creando automáticamente...");
            GameObject composerObj = new GameObject("CharacterSystemComposer");
            characterSystemComposer = composerObj.AddComponent<CharacterSystemComposer>();
        }
        
        characterController = characterSystemComposer.CreateCharacterController(CharacterType.Player, gameObject);
        
        // Conectar eventos
        var deathHandler = characterController?.GetComponent<IDeathHandler>();
        if (deathHandler != null)
        {
            deathHandler.OnDeath += () => OnPlayerDead?.Invoke();
            Debug.Log("[Player] ✅ Usando CharacterSystemComposer (Clean Architecture)");
        }
        else
        {
            Debug.LogWarning("[Player] ⚠️ No se pudo crear CharacterController - usando componente Health legacy como fallback");
            
            // Fallback a sistema legacy si falla
            var healthComponent = GetComponent<global::Health>();
            if (healthComponent != null)
            {
                healthComponent.OnDead += () => OnPlayerDead?.Invoke();
                Debug.LogWarning("[Player] Usando Health component legacy (no recomendado)");
            }
        }
    }
    
    private void OnDestroy()
    {
        // Limpiar el controlador
        if (characterSystemComposer != null && gameObject != null)
        {
            characterSystemComposer.CleanupController(gameObject);
        }
    }
}
