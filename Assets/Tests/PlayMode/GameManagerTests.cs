using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

namespace Tests.PlayMode
{
    /// <summary>
    /// Tests para GameManager
    /// Valida: Gestión de estado del juego, victoria, derrota
    /// </summary>
    public class GameManagerTests
    {
        private GameObject gameManagerObject;
        private GameManager gameManager;
        private GameObject testCamera;

        [UnitySetUp]
        public IEnumerator SetUp()
        {
            // IMPORTANTE: Crear cámara PRIMERO y esperar un frame
            testCamera = new GameObject("TestCamera");
            var camera = testCamera.AddComponent<Camera>();
            camera.tag = "MainCamera";
            camera.orthographic = true;
            camera.backgroundColor = Color.black;
            
            // Esperar para que Unity registre Camera.main
            yield return null;
            
            // Verificar que la cámara está disponible
            Assert.IsNotNull(Camera.main, "Camera.main debe estar disponible");
            
            // Limpiar instancia anterior
            if (GameManager.Instance != null)
            {
                Object.DestroyImmediate(GameManager.Instance.gameObject);
            }

            gameManagerObject = new GameObject("GameManager");
            gameManager = gameManagerObject.AddComponent<GameManager>();
            
            yield return null;
        }

        [UnityTest]
        public IEnumerator GameManager_InitializesCorrectly()
        {
            // Act
            yield return new WaitForSeconds(0.2f);

            // Assert
            Assert.IsNotNull(GameManager.Instance);
            Assert.AreEqual(1f, Time.timeScale, "El juego debe empezar sin pausa");
        }

        [UnityTest]
        public IEnumerator GameManager_CurrentScore_StartsAtZero()
        {
            // Act
            yield return new WaitForSeconds(0.1f);

            // Assert
            Assert.AreEqual(0, gameManager.CurrentScore);
        }

        [UnityTest]
        public IEnumerator GameManager_Progress_CalculatesCorrectly()
        {
            // Arrange
            yield return new WaitForSeconds(0.1f);
            int requiredScore = gameManager.RequiredScore;

            // Act - Simular añadir score (a través de reflejo si es privado)
            var scoreField = typeof(GameManager).GetField("currentScore", 
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            scoreField.SetValue(gameManager, requiredScore / 2);

            // Assert
            Assert.AreEqual(0.5f, gameManager.Progress, 0.01f);
        }

        [UnityTearDown]
        public IEnumerator TearDown()
        {
            if (gameManagerObject != null)
                Object.DestroyImmediate(gameManagerObject);
            
            if (testCamera != null)
                Object.DestroyImmediate(testCamera);
            
            yield return null;
        }
    }
}
