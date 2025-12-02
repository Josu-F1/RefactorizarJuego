using UnityEngine;
using System;

namespace PoolSystem.Models
{
    /// <summary>
    /// Estadísticas de rendimiento de pools
    /// Principio: Single Responsibility Principle (SRP) - Solo datos estadísticos
    /// </summary>
    [System.Serializable]
    public struct PoolStatistics
    {
        public PoolObjectType type;
        public int totalCreated;
        public int currentActive;
        public int currentInactive;
        public int maxCapacity;
        public float utilizationRate;
        public bool canExpand;

        public PoolStatistics(PoolObjectType type, int created, int active, int inactive, int max, bool expand)
        {
            this.type = type;
            totalCreated = created;
            currentActive = active;
            currentInactive = inactive;
            maxCapacity = max;
            utilizationRate = max > 0 ? (float)active / max : 0f;
            canExpand = expand;
        }
    }

    /// <summary>
    /// Configuración completa de un pool
    /// Principio: Single Responsibility Principle (SRP) - Solo configuración
    /// </summary>
    [System.Serializable]
    public class PoolConfiguration : PoolSystem.Interfaces.IPoolConfiguration
    {
        [SerializeField] private PoolObjectType type;
        [SerializeField] private GameObject prefab;
        [SerializeField] private int initialCount = 5;
        [SerializeField] private int maxCount = 20;
        [SerializeField] private bool autoExpand = true;
        [SerializeField] private Color defaultColor = Color.white;

        public PoolObjectType Type => type;
        public GameObject Prefab => prefab;
        public int InitialCount => initialCount;
        public int MaxCount => maxCount;
        public bool AutoExpand => autoExpand;
        public Color DefaultColor => defaultColor;

        public PoolConfiguration(PoolObjectType type, GameObject prefab, int initial = 5, int max = 20)
        {
            this.type = type;
            this.prefab = prefab;
            initialCount = initial;
            maxCount = max;
            autoExpand = true;
            defaultColor = Color.white;
        }
    }
}

namespace PoolSystem.Interfaces
{
    /// <summary>
    /// Interfaz para objetos que pueden ser pooled
    /// Patrón: Object Pool Pattern
    /// Principio: Interface Segregation Principle (ISP) - Solo métodos necesarios para pooling
    /// </summary>
    public interface IPoolable
    {
        /// <summary>
        /// Tipo de objeto para identificación en pools
        /// </summary>
        PoolObjectType Type { get; set; }
        
        /// <summary>
        /// Activa el objeto al ser obtenido del pool
        /// </summary>
        void OnGetFromPool();
        
        /// <summary>
        /// Desactiva el objeto al ser devuelto al pool
        /// </summary>
        void OnReturnToPool();
        
        /// <summary>
        /// Reinicia el objeto a su estado inicial
        /// </summary>
        void ResetState();
    }

    /// <summary>
    /// Interfaz para configuración de pools
    /// Principio: Single Responsibility Principle (SRP) - Solo configuración
    /// </summary>
    public interface IPoolConfiguration
    {
        PoolObjectType Type { get; }
        GameObject Prefab { get; }
        int InitialCount { get; }
        int MaxCount { get; }
        bool AutoExpand { get; }
        Color DefaultColor { get; }
    }

    /// <summary>
    /// Interfaz para estrategias de pooling
    /// Patrón: Strategy Pattern
    /// Principio: Open/Closed Principle (OCP) - Extensible sin modificación
    /// </summary>
    public interface IPoolStrategy
    {
        /// <summary>
        /// Obtiene un objeto del pool
        /// </summary>
        IPoolable GetFromPool(IPoolRepository repository, PoolObjectType type);
        
        /// <summary>
        /// Devuelve un objeto al pool
        /// </summary>
        void ReturnToPool(IPoolRepository repository, IPoolable poolable);
        
        /// <summary>
        /// Verifica si el pool puede expandirse
        /// </summary>
        bool CanExpand(IPoolConfiguration config, int currentCount);
    }

    /// <summary>
    /// Interfaz para repositorio de pools
    /// Patrón: Repository Pattern
    /// Principio: Dependency Inversion Principle (DIP) - Abstracción de almacenamiento
    /// </summary>
    public interface IPoolRepository
    {
        /// <summary>
        /// Inicializa un pool específico
        /// </summary>
        void InitializePool(IPoolConfiguration config);
        
        /// <summary>
        /// Obtiene un objeto del pool
        /// </summary>
        IPoolable Get(PoolObjectType type, Vector3 position, Quaternion rotation);
        
        /// <summary>
        /// Devuelve un objeto al pool
        /// </summary>
        void Return(IPoolable poolable);
        
        /// <summary>
        /// Obtiene estadísticas del pool
        /// </summary>
        PoolSystem.Models.PoolStatistics GetPoolStatistics(PoolObjectType type);
        
        /// <summary>
        /// Limpia todos los pools
        /// </summary>
        void ClearAllPools();
        
        /// <summary>
        /// Verifica si existe un pool para el tipo especificado
        /// </summary>
        bool HasPool(PoolObjectType type);
    }

    /// <summary>
    /// Interfaz para fábrica de objetos pooled
    /// Patrón: Factory Pattern
    /// Principio: Single Responsibility Principle (SRP) - Solo creación
    /// </summary>
    public interface IPoolObjectFactory
    {
        /// <summary>
        /// Crea una nueva instancia de objeto pooled
        /// </summary>
        IPoolable CreatePoolObject(IPoolConfiguration config);
        
        /// <summary>
        /// Configura un objeto pooled existente
        /// </summary>
        void ConfigurePoolObject(IPoolable poolable, IPoolConfiguration config);
        
        /// <summary>
        /// Valida si un prefab puede ser usado en pools
        /// </summary>
        bool CanCreateFrom(GameObject prefab);
    }

    /// <summary>
    /// Interfaz para servicios de pool
    /// Patrón: Facade Pattern
    /// Principio: Interface Segregation Principle (ISP) - API simplificada
    /// </summary>
    public interface IPoolService
    {
        /// <summary>
        /// Obtiene un objeto del pool en una posición específica
        /// </summary>
        T Get<T>(PoolObjectType type, Vector3 position) where T : class, IPoolable;
        
        /// <summary>
        /// Obtiene un objeto del pool con posición y rotación
        /// </summary>
        T Get<T>(PoolObjectType type, Vector3 position, Quaternion rotation) where T : class, IPoolable;
        
        /// <summary>
        /// Devuelve un objeto al pool
        /// </summary>
        void Return(IPoolable poolable);
        
        /// <summary>
        /// Spawn inmediato de objeto (get + configure)
        /// </summary>
        void Spawn(PoolObjectType type, Vector3 position, Color? color = null);
        
        /// <summary>
        /// Precarga un pool con objetos
        /// </summary>
        void WarmupPool(PoolObjectType type, int count);
        
        /// <summary>
        /// Obtiene estadísticas de rendimiento
        /// </summary>
        PoolSystem.Models.PoolStatistics GetStatistics(PoolObjectType type);
    }

    /// <summary>
    /// Interfaz para observadores de eventos de pool
    /// Patrón: Observer Pattern
    /// Principio: Open/Closed Principle (OCP) - Extensible para notificaciones
    /// </summary>
    public interface IPoolObserver
    {
        void OnObjectCreated(PoolObjectType type, IPoolable poolable);
        void OnObjectReturned(PoolObjectType type, IPoolable poolable);
        void OnObjectRetrieved(PoolObjectType type, IPoolable poolable);
        void OnPoolExpanded(PoolObjectType type, int newSize);
    }

    /// <summary>
    /// Interfaz para sujeto observable de pools
    /// Patrón: Observer Pattern
    /// </summary>
    public interface IPoolSubject
    {
        void Subscribe(IPoolObserver observer);
        void Unsubscribe(IPoolObserver observer);
        void NotifyObjectCreated(PoolObjectType type, IPoolable poolable);
        void NotifyObjectReturned(PoolObjectType type, IPoolable poolable);
        void NotifyObjectRetrieved(PoolObjectType type, IPoolable poolable);
        void NotifyPoolExpanded(PoolObjectType type, int newSize);
    }
}