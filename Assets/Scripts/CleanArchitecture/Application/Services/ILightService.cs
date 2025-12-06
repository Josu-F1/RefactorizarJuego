using UnityEngine;

namespace CleanArchitecture.Application.Services
{
    /// <summary>
    /// Servicio de sistema de iluminación
    /// </summary>
    public interface ILightService
    {
        /// <summary>
        /// Registra una luz en el sistema
        /// </summary>
        void RegisterLight(object lightController);

        /// <summary>
        /// Desregistra una luz
        /// </summary>
        void UnregisterLight(object lightController);

        /// <summary>
        /// Establece la intensidad global
        /// </summary>
        void SetGlobalIntensity(float intensity);

        /// <summary>
        /// Establece el color global
        /// </summary>
        void SetGlobalColor(Color color);

        /// <summary>
        /// Activa/desactiva todas las luces
        /// </summary>
        void SetAllLightsEnabled(bool enabled);

        /// <summary>
        /// Fade de intensidad global
        /// </summary>
        void FadeGlobalIntensity(float targetIntensity, float duration);

        /// <summary>
        /// Número de luces registradas
        /// </summary>
        int RegisteredLightCount { get; }

        /// <summary>
        /// Limpia todas las luces
        /// </summary>
        void ClearAllLights();
    }
}
