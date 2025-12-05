using UnityEngine;
using System.Collections.Generic;
using PoolSystem.Interfaces;

namespace PoolSystem.Models
{
    /// <summary>
    /// Implementación de sujeto observable para pools
    /// Patrón: Observer Pattern
    /// Principio: Single Responsibility Principle (SRP) - Solo notificaciones
    /// </summary>
    public class PoolSubject : IPoolSubject
    {
        private List<IPoolObserver> observers = new List<IPoolObserver>();

        public void Subscribe(IPoolObserver observer)
        {
            if (observer != null && !observers.Contains(observer))
            {
                observers.Add(observer);
            }
        }

        public void Unsubscribe(IPoolObserver observer)
        {
            if (observer != null)
            {
                observers.Remove(observer);
            }
        }

        public void NotifyObjectCreated(PoolObjectType type, IPoolable poolable)
        {
            foreach (var observer in observers)
            {
                observer.OnObjectCreated(type, poolable);
            }
        }

        public void NotifyObjectReturned(PoolObjectType type, IPoolable poolable)
        {
            foreach (var observer in observers)
            {
                observer.OnObjectReturned(type, poolable);
            }
        }

        public void NotifyObjectRetrieved(PoolObjectType type, IPoolable poolable)
        {
            foreach (var observer in observers)
            {
                observer.OnObjectRetrieved(type, poolable);
            }
        }

        public void NotifyPoolExpanded(PoolObjectType type, int newSize)
        {
            foreach (var observer in observers)
            {
                observer.OnPoolExpanded(type, newSize);
            }
        }
    }

    /// <summary>
    /// Datos internos de un pool individual
    /// Principio: Encapsulation - Datos privados con acceso controlado
    /// </summary>
    public class PoolData
    {
        public IPoolConfiguration Configuration { get; private set; }
        public GameObject Container { get; private set; }
        public Queue<IPoolable> AvailableObjects { get; private set; }
        public HashSet<IPoolable> ActiveObjects { get; private set; }
        public int TotalCreated { get; set; }

        public PoolData(IPoolConfiguration config, Transform parentTransform)
        {
            Configuration = config;
            AvailableObjects = new Queue<IPoolable>();
            ActiveObjects = new HashSet<IPoolable>();
            TotalCreated = 0;

            // Crear contenedor
            Container = new GameObject($"{config.Type} Pool Container");
            Container.transform.SetParent(parentTransform);
        }

        public void Cleanup()
        {
            AvailableObjects.Clear();
            ActiveObjects.Clear();
            if (Container != null)
            {
                Object.DestroyImmediate(Container);
            }
        }
    }

    /// <summary>
    /// Observador de estadísticas y debugging de pools
    /// Patrón: Observer Pattern
    /// Principio: Single Responsibility Principle (SRP) - Solo logging/debugging
    /// </summary>
    public class PoolDebugObserver : IPoolObserver
    {
        private bool enableLogging;
        private Dictionary<PoolObjectType, int> creationCounts;

        public PoolDebugObserver(bool enableLogging = false)
        {
            this.enableLogging = enableLogging;
            creationCounts = new Dictionary<PoolObjectType, int>();
        }

        public void OnObjectCreated(PoolObjectType type, IPoolable poolable)
        {
            if (!creationCounts.ContainsKey(type))
                creationCounts[type] = 0;
            
            creationCounts[type]++;
            
            if (enableLogging)
            {
                Debug.Log($"[PoolDebug] Created {type} object #{creationCounts[type]}");
            }
        }

        public void OnObjectReturned(PoolObjectType type, IPoolable poolable)
        {
            if (enableLogging)
            {
                Debug.Log($"[PoolDebug] Returned {type} object to pool");
            }
        }

        public void OnObjectRetrieved(PoolObjectType type, IPoolable poolable)
        {
            if (enableLogging)
            {
                Debug.Log($"[PoolDebug] Retrieved {type} object from pool");
            }
        }

        public void OnPoolExpanded(PoolObjectType type, int newSize)
        {
            if (enableLogging)
            {
                Debug.Log($"[PoolDebug] Pool {type} expanded to size {newSize}");
            }
        }

        public int GetCreationCount(PoolObjectType type)
        {
            return creationCounts.GetValueOrDefault(type, 0);
        }

        public void ResetStatistics()
        {
            creationCounts.Clear();
        }
    }
}

namespace PoolSystem.Core
{
    /// <summary>
    /// Objeto pooled mejorado con nueva interfaz
    /// Patrón: Template Method Pattern
    /// Principio: Liskov Substitution Principle (LSP) - Sustituible por subclases
    /// </summary>
    public class PoolableObject : MonoBehaviour, IPoolable
    {
        [SerializeField] private PoolObjectType type;
        public PoolObjectType Type 
        { 
            get => type; 
            set => type = value; 
        }

        protected virtual void Awake()
        {
            // Configuración base
        }

        public virtual void OnGetFromPool()
        {
            gameObject.SetActive(true);
            OnActivated();
        }

        public virtual void OnReturnToPool()
        {
            OnDeactivated();
            gameObject.SetActive(false);
        }

        public virtual void ResetState()
        {
            // Reiniciar transform
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
            
            OnStateReset();
        }

        /// <summary>
        /// Template method para activación personalizada
        /// </summary>
        protected virtual void OnActivated() { }
        
        /// <summary>
        /// Template method para desactivación personalizada
        /// </summary>
        protected virtual void OnDeactivated() { }
        
        /// <summary>
        /// Template method para reset personalizado
        /// </summary>
        protected virtual void OnStateReset() { }

        /// <summary>
        /// Método público para devolución al pool
        /// </summary>
        public void ReturnToPool()
        {
            var poolService = PoolSystemComposer.GetPoolService();
            poolService?.Return(this);
        }
    }

    /// <summary>
    /// Adaptador para compatibilidad con PoolObject legacy
    /// Patrón: Adapter Pattern
    /// Principio: Open/Closed Principle (OCP) - Extensión sin modificación del código legacy
    /// </summary>
    public class LegacyPoolObjectAdapter : PoolableObject
    {
        private PoolObject legacyPoolObject;

        protected override void Awake()
        {
            base.Awake();
            legacyPoolObject = GetComponent<PoolObject>();
            if (legacyPoolObject != null)
            {
                // Sincronizar tipo
                Type = legacyPoolObject.Type;
            }
        }

        protected override void OnActivated()
        {
            // Mantener comportamiento legacy si existe
            if (legacyPoolObject != null)
            {
                // Invocar lógica legacy si es necesaria
            }
        }

        protected override void OnDeactivated()
        {
            // Mantener comportamiento legacy si existe
            if (legacyPoolObject != null)
            {
                // Invocar lógica legacy si es necesaria
            }
        }
    }
}