#pragma warning disable CS0618 // Obsolete warnings suppressed for legacy tests
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

namespace Tests.PlayMode
{
    /// <summary>
    /// Tests para BlockSystemComposer
    /// Valida: Sistema de bloques destructibles
    /// </summary>
    public class BlockSystemTests
    {
        private GameObject composerObject;
        private BlockSystemComposer composer;

        [SetUp]
        public void SetUp()
        {
            if (BlockSystemComposer.Instance != null)
            {
                Object.DestroyImmediate(BlockSystemComposer.Instance.gameObject);
            }

            composerObject = new GameObject("BlockSystemComposer");
            composer = composerObject.AddComponent<BlockSystemComposer>();
        }

        [UnityTest]
        public IEnumerator BlockSystem_Initializes()
        {
            // Act
            yield return new WaitForSeconds(0.2f);

            // Assert
            Assert.IsNotNull(BlockSystemComposer.Instance);
        }

        [UnityTest]
        public IEnumerator BlockSystem_CanInitialize()
        {
            // Arrange
            yield return new WaitForSeconds(0.2f);

            // Act & Assert - Validar que el sistema existe
            Assert.IsNotNull(composer, "BlockSystemComposer should exist");
            Assert.IsNotNull(BlockSystemComposer.Instance, "BlockSystemComposer singleton should be set");
        }

        [TearDown]
        public void TearDown()
        {
            if (composerObject != null)
                Object.DestroyImmediate(composerObject);
        }
    }
}
