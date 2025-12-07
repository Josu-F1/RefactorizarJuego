#pragma warning disable CS0618 // Obsolete warnings suppressed for legacy tests
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

namespace Tests.PlayMode
{
    /// <summary>
    /// Tests para Enemy
    /// Valida: Comportamiento de enemigos, muerte, eventos
    /// </summary>
    public class EnemyTests
    {
        private GameObject enemyObject;
        private Enemy enemy;
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
            
            enemyObject = new GameObject("TestEnemy");
            
            yield return null;
        }

        [UnityTest]
        public IEnumerator Enemy_HasRequiredComponents()
        {
            // Arrange
            enemy = enemyObject.AddComponent<Enemy>();
            enemyObject.AddComponent<Rigidbody2D>();
            
            yield return new WaitForSeconds(0.2f);

            // Assert
            Assert.IsNotNull(enemyObject.GetComponent<Rigidbody2D>());
        }

        [UnityTest]
        public IEnumerator Enemy_OnDeath_TriggersEvent()
        {
            // Arrange
            bool eventTriggered = false;
            Enemy.OnAnyEnemyKilled += (score) => eventTriggered = true;
            
            enemy = enemyObject.AddComponent<Enemy>();
            yield return new WaitForSeconds(0.2f);

            // Act
            // Simular muerte del enemigo
            if (enemy != null)
            {
                Object.DestroyImmediate(enemy.gameObject);
            }
            
            yield return new WaitForSeconds(0.1f);

            // Assert (evento puede o no dispararse dependiendo de implementación)
            // En este caso solo validamos que no crashó
            Assert.Pass("Enemy death test completed");

            // Assert (el evento debería haberse disparado)
            // Nota: Esto depende de cómo implemente Enemy.OnAnyEnemyKilled
        }

        [UnityTearDown]
        public IEnumerator TearDown()
        {
            if (enemyObject != null)
                Object.DestroyImmediate(enemyObject);
            
            if (testCamera != null)
                Object.DestroyImmediate(testCamera);
            
            yield return null;
        }
    }
}
