#pragma warning disable CS0618 // Obsolete warnings suppressed for legacy tests
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
            bool healthChanged = false;
            health.OnHealthChanged += (delta) => healthChanged = true;
            yield return new WaitForSeconds(0.1f);

            // Act
            health.TakeDamage(20);
            yield return new WaitForSeconds(0.1f);

            // Assert
            Assert.IsTrue(healthChanged, "Health should change after taking damage");
        }

        [UnityTest]
        public IEnumerator Heal_IncreasesCurrentHealth()
        {
            // Arrange
            health.TakeDamage(30);
            yield return new WaitForSeconds(0.1f);
            bool healed = false;
            health.OnHealthChanged += (delta) => { if (delta > 0) healed = true; };

            // Act
            health.Heal(15);
            yield return new WaitForSeconds(0.1f);

            // Assert
            Assert.IsTrue(healed, "Heal should trigger health change");
        }

        [UnityTest]
        public IEnumerator TakeDamage_ToZero_TriggersDeathEvent()
        {
            // Arrange
            bool deathTriggered = false;
            health.OnDead += () => deathTriggered = true;
            yield return new WaitForSeconds(0.1f);

            // Act
            health.TakeDamage(999);
            yield return new WaitForSeconds(0.2f);

            // Assert
            Assert.IsTrue(health.IsDead, "Health should be dead after fatal damage");
            Assert.IsTrue(deathTriggered, "OnDead event should trigger");
        }

        [TearDown]
        public void TearDown()
        {
            if (testObject != null)
                Object.DestroyImmediate(testObject);
        }
    }
}
