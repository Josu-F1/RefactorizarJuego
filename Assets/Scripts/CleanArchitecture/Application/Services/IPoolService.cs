using UnityEngine;

namespace CleanArchitecture.Application.Services
{
    /// <summary>
    /// Servicio de Object Pooling
    /// Reemplaza PoolManager singleton
    /// </summary>
    public interface IPoolService
    {
        /// <summary>
        /// Obtiene un objeto del pool
        /// </summary>
        GameObject Get(GameObject prefab);

        /// <summary>
        /// Obtiene un objeto del pool en una posición y rotación
        /// </summary>
        GameObject Get(GameObject prefab, Vector3 position, Quaternion rotation);

        /// <summary>
        /// Devuelve un objeto al pool
        /// </summary>
        void Release(GameObject obj);

        /// <summary>
        /// Pre-instancia objetos en el pool
        /// </summary>
        void Warmup(GameObject prefab, int count);

        /// <summary>
        /// Limpia todo el pool
        /// </summary>
        void Clear();

        /// <summary>
        /// Limpia el pool de un prefab específico
        /// </summary>
        void ClearPool(GameObject prefab);
    }
}
