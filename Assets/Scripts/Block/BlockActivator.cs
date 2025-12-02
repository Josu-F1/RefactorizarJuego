using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// OBSOLETO: Usar BlockSystemComposer en su lugar
/// Redirige automáticamente al nuevo sistema si está disponible
/// </summary>
[System.Obsolete("Use BlockSystemComposer instead. This will be removed in future versions.")]
public class BlockActivator : MonoBehaviour
{
    private void Start()
    {
        Debug.LogWarning("[OBSOLETE] BlockActivator is deprecated. Use BlockSystemComposer instead.");
    }
    
    /// <summary>
    /// Activar todos los bloques
    /// </summary>
    public void ActivateAllBlocks()
    {
        if (BlockSystemComposer.Instance != null)
        {
            var blocks = BlockSystemComposer.Instance.GetAllBlocks();
            foreach (var block in blocks)
            {
                BlockSystemComposer.Instance.ActivateBlock(block.BlockId);
            }
        }
        else
        {
            Block[] blocks = FindObjectsOfType<Block>();
            foreach (Block block in blocks)
            {
                block.ActivateBlock();
            }
        }
    }
    
    /// <summary>
    /// Desactivar bloque
    /// </summary>
    public void DeactiveBlock()
    {
        if (BlockSystemComposer.Instance != null)
        {
            var blocks = BlockSystemComposer.Instance.GetAllBlocks();
            foreach (var block in blocks)
            {
                BlockSystemComposer.Instance.DeactivateBlock(block.BlockId);
            }
        }
        else
        {
            Block[] blocks = FindObjectsOfType<Block>();
            foreach (Block block in blocks)
            {
                block.DeactivateBlock();
            }
        }
    }
}
