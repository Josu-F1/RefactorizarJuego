#pragma warning disable CS0618 // Type or member is obsolete
using UnityEngine;
using System.Collections.Generic;
using System;

/// <summary>
/// Sistema principal de bloques - VERSIÓN FINAL FUNCIONAL
/// Patrón: Facade + Factory + Strategy
/// </summary>
[System.Obsolete("BlockSystemComposer is deprecated. Use IBlockService from ServiceLocator instead.")]
public class BlockSystemComposer : MonoBehaviour
{
    [Header("Block System Configuration")]
    [SerializeField] private bool enableDebugLogging = false;
    [SerializeField] private int maxActiveBlocks = 1000;

    private static BlockSystemComposer instance;
    public static BlockSystemComposer Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<BlockSystemComposer>();
            }
            return instance;
        }
    }

    private Dictionary<int, BlockCore> activeBlocks = new Dictionary<int, BlockCore>();
    private Dictionary<int, string> blockStates = new Dictionary<int, string>();
    private int nextBlockId = 1;

    public event Action<BlockCore> OnBlockCreated;
    public event Action<BlockCore> OnBlockDestroyed;
    public event Action<BlockCore> OnBlockActivated;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Debug.Log("[BlockSystemComposer] Block System initialized successfully!");
    }

    public BlockCore CreateStandardBlock(Vector2 position)
    {
        return CreateBlock("Standard", position);
    }

    public BlockCore CreateIndestructibleBlock(Vector2 position)
    {
        return CreateBlock("Indestructible", position);
    }

    public BlockCore CreateTemporaryBlock(Vector2 position, float duration = 5f)
    {
        var block = CreateBlock("Temporary", position);
        if (block != null)
        {
            StartCoroutine(DestroyBlockAfterDelay(block, duration));
        }
        return block;
    }

    public BlockCore CreateInteractiveBlock(Vector2 position)
    {
        return CreateBlock("Interactive", position);
    }

    public void ActivateBlock(int blockId)
    {
        if (activeBlocks.TryGetValue(blockId, out BlockCore block))
        {
            block.Activate();
            blockStates[blockId] = "Active";
            OnBlockActivated?.Invoke(block);
        }
    }

    public void DeactivateBlock(int blockId)
    {
        if (activeBlocks.TryGetValue(blockId, out BlockCore block))
        {
            block.Deactivate();
            blockStates[blockId] = "Inactive";
        }
    }

    public void DestroyBlock(int blockId)
    {
        if (activeBlocks.TryGetValue(blockId, out BlockCore block))
        {
            block.StartDestruction();
            activeBlocks.Remove(blockId);
            blockStates.Remove(blockId);
            OnBlockDestroyed?.Invoke(block);
        }
    }

    public BlockCore GetBlock(int blockId)
    {
        activeBlocks.TryGetValue(blockId, out BlockCore block);
        return block;
    }

    public List<BlockCore> GetAllBlocks()
    {
        return new List<BlockCore>(activeBlocks.Values);
    }

    public void ClearAllBlocks()
    {
        var blocksToDestroy = new List<int>(activeBlocks.Keys);
        foreach (var blockId in blocksToDestroy)
        {
            DestroyBlock(blockId);
        }
    }

    private BlockCore CreateBlock(string blockType, Vector2 position)
    {
        if (activeBlocks.Count >= maxActiveBlocks)
        {
            if (enableDebugLogging)
            {
                Debug.LogWarning("[BlockSystemComposer] Maximum active blocks reached!");
            }
            return null;
        }

        try
        {
            GameObject blockObj = new GameObject($"Block_{blockType}_{nextBlockId}");
            blockObj.transform.position = position;

            var block = blockObj.AddComponent<BlockCore>();
            block.Initialize(nextBlockId, blockType, this);

            activeBlocks[nextBlockId] = block;
            blockStates[nextBlockId] = "Inactive";
            
            nextBlockId++;

            OnBlockCreated?.Invoke(block);

            if (enableDebugLogging)
            {
                Debug.Log($"[BlockSystemComposer] Created {blockType} block at {position}");
            }

            return block;
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"[BlockSystemComposer] Error creating block: {ex.Message}");
            return null;
        }
    }

    private System.Collections.IEnumerator DestroyBlockAfterDelay(BlockCore block, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (block != null)
        {
            DestroyBlock(block.BlockId);
        }
    }

    public void PrintSystemInfo()
    {
        Debug.Log($"[BlockSystemComposer] Active Blocks: {activeBlocks.Count}/{maxActiveBlocks}");
        Debug.Log($"[BlockSystemComposer] Registered States: {blockStates.Count}");
    }
}

/// <summary>
/// Componente principal de bloque - VERSIÓN FUNCIONAL
/// </summary>
public class BlockCore : MonoBehaviour
{
    private int blockId;
    private string blockType;
    private float health;
    private bool isActive = false;
    private BlockSystemComposer blockSystem;

    public int BlockId => blockId;
    public string BlockType => blockType;
    public bool IsActive => isActive;
    public float Health => health;

    public void Initialize(int id, string type, BlockSystemComposer system)
    {
        blockId = id;
        blockType = type;
        blockSystem = system;

        switch (blockType)
        {
            case "Standard":
                health = 100f;
                break;
            case "Indestructible":
                health = float.MaxValue;
                break;
            case "Temporary":
                health = 50f;
                break;
            case "Interactive":
                health = 75f;
                break;
        }

        SetupVisuals();
    }

    private void SetupVisuals()
    {
        var renderer = gameObject.AddComponent<SpriteRenderer>();
        var collider = gameObject.AddComponent<BoxCollider2D>();

        switch (blockType)
        {
            case "Standard":
                renderer.color = Color.white;
                break;
            case "Indestructible":
                renderer.color = Color.gray;
                break;
            case "Temporary":
                renderer.color = Color.yellow;
                break;
            case "Interactive":
                renderer.color = Color.blue;
                break;
        }
    }

    public void Activate()
    {
        isActive = true;
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        isActive = false;
        gameObject.SetActive(false);
    }

    public void TakeDamage(float damage)
    {
        if (blockType == "Indestructible") return;

        health -= damage;
        if (health <= 0)
        {
            StartDestruction();
        }
    }

    public void StartDestruction()
    {
        StartCoroutine(DestroySequence());
    }

    private System.Collections.IEnumerator DestroySequence()
    {
        float destroyTime = 0.5f;
        float elapsed = 0f;
        Vector3 originalScale = transform.localScale;

        while (elapsed < destroyTime)
        {
            elapsed += Time.deltaTime;
            float progress = elapsed / destroyTime;
            transform.localScale = Vector3.Lerp(originalScale, Vector3.zero, progress);
            yield return null;
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (blockType == "Interactive" && other.CompareTag("Player"))
        {
            Debug.Log($"[BlockCore] Player interacted with block {blockId}");
        }
    }
}

/// <summary>
/// Puente de compatibilidad para Block existente - OBSOLETO
/// </summary>
[System.Obsolete("Use BlockSystemComposer instead")]
public class BlockCompat : MonoBehaviour
{
    private void Start()
    {
        Debug.LogWarning("[OBSOLETE] Block is deprecated. Use BlockSystemComposer instead.");
    }

    public static BlockCore CreateBlock(Vector2 position)
    {
        return BlockSystemComposer.Instance?.CreateStandardBlock(position);
    }

    public void DestroyBlock()
    {
        var blockCore = GetComponent<BlockCore>();
        if (blockCore != null)
        {
            BlockSystemComposer.Instance?.DestroyBlock(blockCore.BlockId);
        }
    }
}

/// <summary>
/// Puente de compatibilidad para BlockActivator existente - OBSOLETO
/// </summary>
[System.Obsolete("Use BlockSystemComposer instead")]
public class BlockActivatorCompat : MonoBehaviour
{
    private void Start()
    {
        Debug.LogWarning("[OBSOLETE] BlockActivator is deprecated. Use BlockSystemComposer instead.");
    }

    public void ActivateAllBlocks()
    {
        var blocks = BlockSystemComposer.Instance?.GetAllBlocks();
        if (blocks != null)
        {
            foreach (var block in blocks)
            {
                BlockSystemComposer.Instance.ActivateBlock(block.BlockId);
            }
        }
    }

    public void ActivateBlock(int blockId)
    {
        BlockSystemComposer.Instance?.ActivateBlock(blockId);
    }
}