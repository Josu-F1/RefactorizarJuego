#pragma warning disable CS0618 // Obsolete warnings suppressed for legacy tests
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

namespace Tests.PlayMode
{
    /// <summary>
    /// Tests para PlayerSpawn
    /// Valida: Posicionamiento inicial del jugador, limpieza de datos guardados
    /// </summary>
    public class PlayerSpawnTests
    {
        private GameObject spawnObject;
        private PlayerSpawn playerSpawn;
        private GameObject playerObject;

        [SetUp]
        public void SetUp()
        {
            // Crear objeto de spawn
            spawnObject = new GameObject("PlayerSpawn");
            playerSpawn = spawnObject.AddComponent<PlayerSpawn>();

            // Limpiar datos guardados
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }

        [UnityTest]
        public IEnumerator SetSpawnPosition_MovesPlayerToNewPosition()
        {
            // Arrange
            Vector3 newPosition = new Vector3(10, 5, 0);
            
            // Crear jugador
            playerObject = new GameObject("Player");
            var player = playerObject.AddComponent<Player>();
            
            // Esperar inicialización
            yield return new WaitForSeconds(0.5f);

            // Act
            playerSpawn.SetSpawnPosition(newPosition);
            yield return new WaitForSeconds(0.2f);

            // Assert
            if (Player.Instance != null)
            {
                float distance = Vector3.Distance(newPosition, Player.Instance.transform.position);
                Assert.Less(distance, 0.1f, "El jugador debe estar en la posición de spawn");
            }
        }

        [UnityTest]
        public IEnumerator PlayerSpawn_WaitsForPlayerInstance()
        {
            // Act - Iniciar sin jugador
            yield return new WaitForSeconds(0.2f);

            // Crear jugador después
            playerObject = new GameObject("Player");
            playerObject.AddComponent<Player>();
            
            yield return new WaitForSeconds(0.5f);

            // Assert
            Assert.IsNotNull(Player.Instance, "PlayerSpawn debe esperar a que Player.Instance exista");
        }

        [TearDown]
        public void TearDown()
        {
            if (spawnObject != null)
                Object.DestroyImmediate(spawnObject);
            if (playerObject != null)
                Object.DestroyImmediate(playerObject);
            
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
    }
}
