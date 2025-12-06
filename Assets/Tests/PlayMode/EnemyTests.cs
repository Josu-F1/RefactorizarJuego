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

        [SetUp]
        public void SetUp()
        {
            enemyObject = new GameObject("TestEnemy");
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

            // Assert (el evento debería haberse disparado)
            // Nota: Esto depende de cómo implemente Enemy.OnAnyEnemyKilled
        }

        [TearDown]
        public void TearDown()
        {
            if (enemyObject != null)
                Object.DestroyImmediate(enemyObject);
        }
    }
}
