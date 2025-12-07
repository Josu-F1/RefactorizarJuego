using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

namespace Tests.PlayMode
{
    /// <summary>
    /// Tests para EndGameDisplay
    /// Valida: Pantalla de victoria/derrota
    /// </summary>
    public class EndGameDisplayTests
    {
        private GameObject displayObject;
        private EndGameDisplay endGameDisplay;
        private GameObject gameManagerObject;

        [SetUp]
        public void SetUp()
        {
            // Crear GameManager primero
            if (GameManager.Instance == null)
            {
                gameManagerObject = new GameObject("GameManager");
                gameManagerObject.AddComponent<GameManager>();
            }

            displayObject = new GameObject("EndGameDisplay");
            endGameDisplay = displayObject.AddComponent<EndGameDisplay>();
        }

        [UnityTest]
        public IEnumerator EndGameDisplay_Initializes()
        {
            // Act
            yield return new WaitForSeconds(0.2f);

            // Assert
            Assert.IsNotNull(endGameDisplay);
        }

        [TearDown]
        public void TearDown()
        {
            if (displayObject != null)
                Object.DestroyImmediate(displayObject);
            if (gameManagerObject != null)
                Object.DestroyImmediate(gameManagerObject);
        }
    }
}
