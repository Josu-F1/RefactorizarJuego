#if UNITY_INCLUDE_TESTS
using UnityEngine;

namespace Tests.PlayMode
{
    /// <summary>
    /// Ensures the Unity Test Runner always has a camera available during PlayMode runs.
    /// </summary>
    internal static class PlayModeCameraBootstrap
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void EnsureCamera()
        {
            if (Camera.main != null)
            {
                return;
            }

            var cameraObject = new GameObject("PlayModeTestCamera");
            var camera = cameraObject.AddComponent<Camera>();
            camera.orthographic = true;
            camera.backgroundColor = Color.black;
            camera.tag = "MainCamera";

            cameraObject.AddComponent<AudioListener>();
            Object.DontDestroyOnLoad(cameraObject);
        }
    }
}
#endif
