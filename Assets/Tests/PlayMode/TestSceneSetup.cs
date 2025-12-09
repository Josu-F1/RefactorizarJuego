using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;
using System.Collections;

namespace Tests.PlayMode
{
    /// <summary>
    /// Clase base para tests PlayMode que necesitan una escena configurada
    /// Crea automáticamente cámara y canvas para evitar "No cameras rendering"
    /// </summary>
    public class TestSceneSetup
    {
        protected GameObject testCamera;
        protected GameObject testCanvas;
        protected GameObject testEventSystem;
        
        [UnitySetUp]
        public IEnumerator SetUp()
        {
            // 1. Crear cámara para evitar "No cameras rendering"
            testCamera = new GameObject("TestCamera");
            var camera = testCamera.AddComponent<Camera>();
            camera.clearFlags = CameraClearFlags.SolidColor;
            camera.backgroundColor = Color.black;
            camera.orthographic = true;
            camera.orthographicSize = 5;
            camera.tag = "MainCamera";
            
            // 2. Crear Canvas para UI tests
            testCanvas = new GameObject("TestCanvas");
            var canvas = testCanvas.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            testCanvas.AddComponent<UnityEngine.UI.CanvasScaler>();
            testCanvas.AddComponent<UnityEngine.UI.GraphicRaycaster>();
            
            // 3. Crear EventSystem para UI
            testEventSystem = new GameObject("TestEventSystem");
            testEventSystem.AddComponent<UnityEngine.EventSystems.EventSystem>();
            testEventSystem.AddComponent<UnityEngine.EventSystems.StandaloneInputModule>();
            
            yield return null; // Espera 1 frame para que se inicialice
        }
        
        [UnityTearDown]
        public IEnumerator TearDown()
        {
            // Limpia objetos de test
            if (testCamera != null) Object.Destroy(testCamera);
            if (testCanvas != null) Object.Destroy(testCanvas);
            if (testEventSystem != null) Object.Destroy(testEventSystem);
            
            // Destruye todos los objetos creados durante el test
            var allGameObjects = Object.FindObjectsOfType<GameObject>();
            foreach (var go in allGameObjects)
            {
                if (go != null && go.scene.name != "DontDestroyOnLoad")
                {
                    Object.Destroy(go);
                }
            }
            
            yield return null;
        }
    }
}
