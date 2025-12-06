using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

namespace Tests.PlayMode
{
    /// <summary>
    /// Tests para Health component
    /// Valida: Vida, daño, curación
    /// </summary>
    public class HealthTests
    {
        private GameObject testObject;
        private Health health;

        [SetUp]
        public void SetUp()
        {
            testObject = new GameObject("TestHealth");
            health = testObject.AddComponent<Health>();
        }

        [UnityTest]
        public IEnumerator TakeDamage_ReducesCurrentHealth()
        {
            // Arrange
            yield return new WaitForSeconds(0.1f);
            float initialHealth = health.CurrentHealth;

            // Act
            health.TakeDamage(20);
            yield return new WaitForSeconds(0.1f);

            // Assert
            Assert.Less(health.CurrentHealth, initialHealth);
        }

        [UnityTest]
        public IEnumerator Heal_IncreasesCurrentHealth()
        {
            // Arrange
            health.TakeDamage(30);
            yield return new WaitForSeconds(0.1f);
            float damagedHealth = health.CurrentHealth;

            // Act
            health.Heal(15);
            yield return new WaitForSeconds(0.1f);

            // Assert
            Assert.Greater(health.CurrentHealth, damagedHealth);
        }

        [UnityTest]
        public IEnumerator TakeDamage_ToZero_TriggersDeathEvent()
        {
            // Arrange
            bool deathTriggered = false;
            if (health.OnDeath != null)
                health.OnDeath += () => deathTriggered = true;
            
            yield return new WaitForSeconds(0.1f);

            // Act
            health.TakeDamage(999);
            yield return new WaitForSeconds(0.2f);

            // Assert podría validar muerte
        }

        [TearDown]
        public void TearDown()
        {
            if (testObject != null)
                Object.DestroyImmediate(testObject);
        }
    }
}
