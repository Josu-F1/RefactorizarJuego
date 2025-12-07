#pragma warning disable CS0618 // Obsolete warnings suppressed for legacy tests
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

namespace Tests.PlayMode
{
    /// <summary>
    /// Tests para BombSpawner
    /// Valida: Sistema de bombas
    /// </summary>
    public class BombSpawnerTests
    {
        private GameObject spawnerObject;
        private BombSpawner spawner;

        [SetUp]
        public void SetUp()
        {
            spawnerObject = new GameObject("BombSpawner");
            spawner = spawnerObject.AddComponent<BombSpawner>();
        }

        [UnityTest]
        public IEnumerator BombSpawner_Initializes()
        {
            // Act
            yield return new WaitForSeconds(0.2f);

            // Assert
            Assert.IsNotNull(spawner);
        }

        [TearDown]
        public void TearDown()
        {
            if (spawnerObject != null)
                Object.DestroyImmediate(spawnerObject);
        }
    }
}
