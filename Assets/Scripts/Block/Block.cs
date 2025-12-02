using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// OBSOLETO: Usar BlockSystemComposer en su lugar
/// Redirige automáticamente al nuevo sistema si está disponible
/// </summary>
[System.Obsolete("Use BlockSystemComposer instead. This will be removed in future versions.")]
public class Block : MonoBehaviour
{
    public int health = 100;
    public bool isDestroyed = false;
    
    // Compatibilidad con nuevo sistema
    private bool useNewSystem => BlockSystemComposer.Instance != null;
    
    private void Start()
    {
        Debug.LogWarning("[OBSOLETE] Block is deprecated. Use BlockSystemComposer instead.");
        
        if (useNewSystem)
        {
            Debug.Log("[Block] Legacy Block redirecting to BlockSystemComposer");
        }
    }
    
    /// <summary>
    /// Crear bloque - redirige al nuevo sistema
    /// </summary>
    public static BlockCore CreateBlock(Vector2 position)
    {
        if (BlockSystemComposer.Instance != null)
        {
            return BlockSystemComposer.Instance.CreateStandardBlock(position);
        }
        return null;
    }
    
    /// <summary>
    /// Tomar daño
    /// </summary>
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            DestroyBlock();
        }
    }
    
    /// <summary>
    /// Destruir bloque
    /// </summary>
    public void DestroyBlock()
    {
        isDestroyed = true;
        Destroy(gameObject);
    }
    
    /// <summary>
    /// Activar bloque - redirige al nuevo sistema
    /// </summary>
    public void ActivateBlock()
    {
        if (useNewSystem)
        {
            // Crear un bloque en el nuevo sistema si no existe
            var newBlock = BlockSystemComposer.Instance.CreateStandardBlock(transform.position);
            if (newBlock != null)
            {
                BlockSystemComposer.Instance.ActivateBlock(newBlock.BlockId);
            }
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
    
    /// <summary>
    /// Desactivar bloque - redirige al nuevo sistema
    /// </summary>
    public void DeactivateBlock()
    {
        gameObject.SetActive(false);
    }
}
