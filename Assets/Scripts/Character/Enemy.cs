#pragma warning disable CS0618 // El tipo o miembro está obsoleto
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
            // Debug.Log("[Enemy] ✅ Usando CharacterSystemComposer (Clean Architecture)");
        }
    }
    
    private bool isDying = false;
    
    private void Die()
    {
        // Prevenir múltiples llamadas
        if (isDying) return;
        isDying = true;
        
        // Solo spawner pickups si el juego está corriendo (no al cambiar escenas)
        if (Application.isPlaying && gameObject.scene.isLoaded)
        {
            // Spawn pickup aleatorio con 30% de probabilidad
            if (UnityEngine.Random.value <= 0.3f)
            {
                SpawnRandomPickup();
            }
            
            // Notificar score
            OnAnyEnemyKilled?.Invoke(score);
        }
    }
    
    private void SpawnRandomPickup()
    {
        // Seleccionar pickup aleatorio
        PickupType[] availablePickups = new PickupType[] 
        {
            PickupType.Health,
            PickupType.Speed,
            PickupType.BombLimit,
            PickupType.BombLength,
            PickupType.Damage
        };
        
        PickupType randomPickup = availablePickups[UnityEngine.Random.Range(0, availablePickups.Length)];
        string prefabPath = $"Assets/Prefabs/Pickups/{GetPickupPrefabName(randomPickup)}.prefab";
        
        // Cargar prefab usando Resources (requiere mover prefabs a Resources) o usar AssetDatabase en editor
        #if UNITY_EDITOR
        GameObject prefab = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
        if (prefab != null)
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
            Debug.Log($"[Enemy] Pickup '{randomPickup}' spawned at {transform.position}");
        }
        else
        {
            Debug.LogWarning($"[Enemy] No se encontr\u00f3 prefab en: {prefabPath}");
        }
        #else
        // En runtime, usar Resources
        GameObject prefab = Resources.Load<GameObject>($"Pickups/{GetPickupPrefabName(randomPickup)}");
        if (prefab != null)
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
        #endif
    }
    
    private string GetPickupPrefabName(PickupType pickupType)
    {
        return pickupType switch
        {
            PickupType.Health => "HealthPickup",
            PickupType.Speed => "SpeedPickup",
            PickupType.BombLimit => "BombLimitPickup",
            PickupType.BombLength => "BombLengthPickup",
            PickupType.Damage => "DamagePickup",
            _ => "HealthPickup"
        };
    }
    
    private void OnDestroy()
    {
        // Ejecutar lógica de muerte antes de destruir
        Die();
        
        // Limpiar CharacterSystemComposer
        if (characterSystemComposer != null && gameObject != null)
        {
            characterSystemComposer.CleanupController(gameObject);
        }
    }
}
