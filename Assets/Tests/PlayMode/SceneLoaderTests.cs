using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Tests.PlayMode
{
    /// <summary>
    /// Tests para SceneLoader
    /// Valida: Carga de escenas, reanudación del juego
    /// </summary>
    public class SceneLoaderTests
    {
        [SetUp]
        public void SetUp()
        {
            Time.timeScale = 1f;
        }

        [UnityTest]
        public IEnumerator LoadCurrentScene_ResumesGame()
        {
            // Arrange
            Time.timeScale = 0f; // Pausar el juego

            // Act
            SceneLoader.LoadCurrentScene();
            yield return new WaitForSeconds(0.5f);

            // Assert
            Assert.AreEqual(1f, Time.timeScale, "SceneLoader debe reanudar el juego");
        }

        [Test]
        public void Load_WithSceneName_DoesNotThrow()
        {
            // Act & Assert
            Assert.DoesNotThrow(() => SceneLoader.Load("MainMenu"));
        }

        [TearDown]
        public void TearDown()
        {
            Time.timeScale = 1f;
        }
    }
}
