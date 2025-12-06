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
[RequireComponent(typeof(Health))]
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
        
        // Obtener el sistema refactorizado
        characterSystemComposer = CharacterSystemComposer.Instance;
    }
    
    private void Start()
    {
        // FORZAR uso de CharacterSystemComposer
        if (characterSystemComposer == null)
        {
            Debug.LogError("[Player] ❌ CharacterSystemComposer no encontrado! El juego requiere Clean Architecture.");
            return;
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
            Debug.LogError("[Player] ❌ No se pudo crear CharacterController");
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
