#if UNITY_INCLUDE_TESTS
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tests.PlayMode
{
    /// <summary>
    /// Ensures the Unity Test Runner always has a camera available during PlayMode runs.
    /// SOLO se ejecuta en escenas de test (InitTestScene)
    /// </summary>
    internal static class PlayModeCameraBootstrap
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void EnsureCamera()
        {
            // SOLO ejecutar si estamos en una escena de test del Test Runner
            string sceneName = SceneManager.GetActiveScene().name;
            if (!sceneName.StartsWith("InitTestScene"))
            {
                return; // No hacer nada en escenas normales del juego
            }

            if (Camera.main != null)
            {
                return;
            }

            var cameraObject = new GameObject("PlayModeTestCamera");
            var camera = cameraObject.AddComponent<Camera>();
            camera.orthographic = true;
            camera.backgroundColor = Color.gray; // Gris para distinguir de escenas normales
            camera.tag = "MainCamera";

            cameraObject.AddComponent<AudioListener>();
            Object.DontDestroyOnLoad(cameraObject);
            
            Debug.Log("[PlayModeCameraBootstrap] Cámara de test creada en: " + sceneName);
        }
    }
}
#endif
