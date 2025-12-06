using UnityEngine;
using System.Collections.Generic;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Infrastructure.DependencyInjection;

namespace CleanArchitecture.Infrastructure.Services
{
    /// <summary>
    /// Servicio de sistema de bloques - Clean Architecture
    /// Migrado desde BlockSystemComposer
    /// </summary>
    public class BlockService : IBlockService
    {
        private readonly Dictionary<int, GameObject> activeBlocks;
        private int nextBlockId = 1;
        private const int MAX_BLOCKS = 1000;

        public int ActiveBlockCount => activeBlocks.Count;

        public BlockService()
        {
            activeBlocks = new Dictionary<int, GameObject>();
        }

        public GameObject CreateStandardBlock(Vector2 position)
        {
            return CreateBlock("Standard", position, 100f, Color.white);
        }

        public GameObject CreateIndestructibleBlock(Vector2 position)
        {
            return CreateBlock("Indestructible", position, float.MaxValue, Color.gray);
        }

        public GameObject CreateBlock(string blockType, Vector2 position)
        {
            return blockType switch
            {
                "Standard" => CreateStandardBlock(position),
                "Indestructible" => CreateIndestructibleBlock(position),
                "Temporary" => CreateBlock("Temporary", position, 50f, Color.yellow),
                "Interactive" => CreateBlock("Interactive", position, 75f, Color.blue),
                _ => CreateStandardBlock(position)
            };
        }

        private GameObject CreateBlock(string blockType, Vector2 position, float health, Color color)
        {
            if (activeBlocks.Count >= MAX_BLOCKS)
            {
                Debug.LogWarning("[BlockService] Maximum active blocks reached!");
                return null;
            }

            try
            {
                GameObject blockObj = new GameObject($"Block_{blockType}_{nextBlockId}");
                blockObj.transform.position = position;

                // Add visual components
                var renderer = blockObj.AddComponent<SpriteRenderer>();
                renderer.color = color;
                
                var collider = blockObj.AddComponent<BoxCollider2D>();

                // Store block
                int blockId = nextBlockId++;
                activeBlocks[blockId] = blockObj;

                // Add a simple component to store block data
                var blockData = blockObj.AddComponent<BlockData>();
                blockData.BlockId = blockId;
                blockData.BlockType = blockType;
                blockData.Health = health;
                blockData.MaxHealth = health;

                Debug.Log($"[BlockService] Created {blockType} block at {position}");
                return blockObj;
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"[BlockService] Error creating block: {ex.Message}");
                return null;
            }
        }

        public void DestroyBlock(GameObject block)
        {
            if (block == null) return;

            var blockData = block.GetComponent<BlockData>();
            if (blockData != null)
            {
                activeBlocks.Remove(blockData.BlockId);
            }

            Object.Destroy(block);
            Debug.Log($"[BlockService] Block destroyed. Remaining: {activeBlocks.Count}");
        }

        public GameObject[] GetAllActiveBlocks()
        {
            var blocks = new GameObject[activeBlocks.Count];
            activeBlocks.Values.CopyTo(blocks, 0);
            return blocks;
        }

        public void ClearAllBlocks()
        {
            var blocksToDestroy = new List<GameObject>(activeBlocks.Values);
            foreach (var block in blocksToDestroy)
            {
                if (block != null)
                {
                    Object.Destroy(block);
                }
            }
            
            activeBlocks.Clear();
            Debug.Log("[BlockService] All blocks cleared");
        }
    }

    /// <summary>
    /// Componente auxiliar para almacenar datos de bloque
    /// </summary>
    public class BlockData : MonoBehaviour
    {
        public int BlockId;
        public string BlockType;
        public float Health;
        public float MaxHealth;
        public bool IsActive = true;

        public void TakeDamage(float damage)
        {
            if (BlockType == "Indestructible") return;

            Health -= damage;
            if (Health <= 0)
            {
                var service = ServiceLocator.Instance.Get<IBlockService>();
                service?.DestroyBlock(gameObject);
            }
        }
    }
}
