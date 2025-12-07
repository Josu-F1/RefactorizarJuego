using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

namespace Tests.PlayMode
{
    /// <summary>
    /// Tests para Movement system
    /// Valida: Movimiento del jugador
    /// </summary>
    public class MovementTests
    {
        private GameObject playerObject;
        private Rigidbody2D rb;

        [SetUp]
        public void SetUp()
        {
            playerObject = new GameObject("TestPlayer");
            rb = playerObject.AddComponent<Rigidbody2D>();
        }

        [UnityTest]
        public IEnumerator Movement_AppliesVelocity()
        {
            // Arrange
            Vector2 moveDirection = Vector2.right;
            float moveSpeed = 5f;
            
            yield return new WaitForSeconds(0.1f);

            // Act
            rb.velocity = moveDirection * moveSpeed;
            yield return new WaitForSeconds(0.2f);

            // Assert
            Assert.Greater(rb.velocity.magnitude, 0);
        }

        [UnityTest]
        public IEnumerator Movement_StopsWhenNoInput()
        {
            // Arrange
            rb.velocity = Vector2.right * 5f;
            yield return new WaitForSeconds(0.1f);

            // Act
            rb.velocity = Vector2.zero;
            yield return new WaitForSeconds(0.1f);

            // Assert
            Assert.AreEqual(Vector2.zero, rb.velocity);
        }

        [TearDown]
        public void TearDown()
        {
            if (playerObject != null)
                Object.DestroyImmediate(playerObject);
        }
    }
}
