using System;
using System.Collections.Generic;
using UnityEngine;

namespace CleanArchitecture.Infrastructure.DependencyInjection
{
    /// <summary>
    /// Service Locator pattern para resolver dependencias
    /// Reemplaza el uso de Singletons estáticos
    /// </summary>
    public class ServiceLocator
    {
        private static ServiceLocator _instance;
        public static ServiceLocator Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ServiceLocator();
                }
                return _instance;
            }
        }

        private readonly Dictionary<Type, object> _services = new Dictionary<Type, object>();

        /// <summary>
        /// Registra un servicio por su interfaz
        /// </summary>
        public void Register<T>(T service) where T : class
        {
            var type = typeof(T);
            
            if (_services.ContainsKey(type))
            {
                Debug.LogWarning($"[ServiceLocator] Servicio {type.Name} ya registrado. Sobrescribiendo...");
                _services[type] = service;
            }
            else
            {
                _services.Add(type, service);
                Debug.Log($"[ServiceLocator] ✅ Servicio {type.Name} registrado");
            }
        }

        /// <summary>
        /// Obtiene un servicio registrado
        /// </summary>
        public T Get<T>() where T : class
        {
            var type = typeof(T);
            
            if (_services.TryGetValue(type, out var service))
            {
                return service as T;
            }

            Debug.LogError($"[ServiceLocator] ❌ Servicio {type.Name} no encontrado");
            return null;
        }

        /// <summary>
        /// Obtiene un servicio registrado sin mostrar error si no existe (para fallback silencioso)
        /// </summary>
        public T GetSilent<T>() where T : class
        {
            var type = typeof(T);
            
            if (_services.TryGetValue(type, out var service))
            {
                return service as T;
            }

            // No mostrar error, solo retornar null para fallback silencioso
            return null;
        }

        /// <summary>
        /// Verifica si un servicio está registrado
        /// </summary>
        public bool Has<T>() where T : class
        {
            return _services.ContainsKey(typeof(T));
        }

        /// <summary>
        /// Desregistra un servicio
        /// </summary>
        public void Unregister<T>() where T : class
        {
            var type = typeof(T);
            if (_services.Remove(type))
            {
                Debug.Log($"[ServiceLocator] Servicio {type.Name} desregistrado");
            }
        }

        /// <summary>
        /// Limpia todos los servicios registrados
        /// </summary>
        public void Clear()
        {
            _services.Clear();
            Debug.Log("[ServiceLocator] Todos los servicios limpiados");
        }

        /// <summary>
        /// Resetea la instancia (útil para testing)
        /// </summary>
        public static void Reset()
        {
            _instance?.Clear();
            _instance = null;
        }
    }
}
