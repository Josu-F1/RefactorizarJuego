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
    
    private Health health;
    private ICharacterController characterController;
    private CharacterSystemComposer characterSystemComposer;
    
    protected override void Awake()
    {
        base.Awake();
        health = GetComponent<Health>();
        
        // Intentar obtener el sistema refactorizado
        characterSystemComposer = CharacterSystemComposer.Instance;
    }
    
    private void Start()
    {
        // Si existe el sistema refactorizado, usarlo
        if (characterSystemComposer != null)
        {
            characterController = characterSystemComposer.CreateCharacterController(CharacterType.Player, gameObject);
            
            // Conectar eventos para compatibilidad
            var deathHandler = characterController?.GetComponent<IDeathHandler>();
            if (deathHandler != null)
            {
                deathHandler.OnDeath += () => OnPlayerDead?.Invoke();
                Debug.Log("[Player] Usando CharacterSystemComposer (SOLID refactorizado)");
            }
        }
        else
        {
            // Sistema legacy (silenciado hasta completar migración)
            health.OnDead += Die;
        }
    }
    
    private void Die()
    {
        OnPlayerDead?.Invoke();
        gameObject.SetActive(false);
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
