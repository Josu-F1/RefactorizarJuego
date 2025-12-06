using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

namespace Tests.PlayMode
{
    /// <summary>
    /// Tests para Player singleton
    /// Valida: Creación de instancia única, persistencia
    /// </summary>
    public class PlayerTests
    {
        private GameObject playerObject;

        [SetUp]
        public void SetUp()
        {
            // Limpiar instancias anteriores
            if (Player.Instance != null)
            {
                Object.DestroyImmediate(Player.Instance.gameObject);
            }
        }

        [UnityTest]
        public IEnumerator Player_CreatesSingleInstance()
        {
            // Act
            playerObject = new GameObject("Player");
            var player = playerObject.AddComponent<Player>();
            
            yield return new WaitForSeconds(0.2f);

            // Assert
            Assert.IsNotNull(Player.Instance);
            Assert.AreEqual(player, Player.Instance);
        }

        [UnityTest]
        public IEnumerator Player_DestroysDuplicateInstances()
        {
            // Arrange
            var player1 = new GameObject("Player1");
            player1.AddComponent<Player>();
            yield return new WaitForSeconds(0.2f);

            // Act - Crear segundo jugador
            var player2 = new GameObject("Player2");
            player2.AddComponent<Player>();
            yield return new WaitForSeconds(0.2f);

            // Assert
            Assert.IsNotNull(Player.Instance, "Debe existir una instancia de Player");
            
            // Solo debe haber UN jugador activo
            var players = Object.FindObjectsOfType<Player>();
            Assert.AreEqual(1, players.Length, "Solo debe haber una instancia de Player");
        }

        [UnityTest]
        public IEnumerator Player_InitializesCharacterController()
        {
            // Arrange
            playerObject = new GameObject("Player");
            playerObject.AddComponent<Player>();
            
            yield return new WaitForSeconds(0.5f);

            // Assert
            Assert.IsNotNull(Player.Instance, "Player debe inicializarse");
            // Verificar que tenga componentes necesarios
            Assert.IsNotNull(playerObject.GetComponent<Rigidbody2D>(), "Player debe tener Rigidbody2D");
        }

        [TearDown]
        public void TearDown()
        {
            if (playerObject != null)
                Object.DestroyImmediate(playerObject);
            
            if (Player.Instance != null)
                Object.DestroyImmediate(Player.Instance.gameObject);
        }
    }
}
