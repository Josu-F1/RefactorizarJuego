using UnityEngine;

namespace CleanArchitecture.Application.Services
{
    /// <summary>
    /// Servicio de sistema de bloques
    /// </summary>
    public interface IBlockService
    {
        /// <summary>
        /// Crea un bloque estándar
        /// </summary>
        GameObject CreateStandardBlock(Vector2 position);

        /// <summary>
        /// Crea un bloque indestructible
        /// </summary>
        GameObject CreateIndestructibleBlock(Vector2 position);

        /// <summary>
        /// Crea un bloque por tipo
        /// </summary>
        GameObject CreateBlock(string blockType, Vector2 position);

        /// <summary>
        /// Destruye un bloque
        /// </summary>
        void DestroyBlock(GameObject block);

        /// <summary>
        /// Obtiene todos los bloques activos
        /// </summary>
        GameObject[] GetAllActiveBlocks();

        /// <summary>
        /// Número de bloques activos
        /// </summary>
        int ActiveBlockCount { get; }

        /// <summary>
        /// Limpia todos los bloques
        /// </summary>
        void ClearAllBlocks();
    }
}
