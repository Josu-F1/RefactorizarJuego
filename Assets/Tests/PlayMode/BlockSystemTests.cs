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
        public IEnumerator CreateBlock_CreatesValidBlock()
        {
            // Arrange
            yield return new WaitForSeconds(0.2f);

            // Act
            var blockId = composer.CreateBlock(BlockType.Brick, Vector2.zero);
            yield return new WaitForSeconds(0.1f);

            // Assert
            Assert.Greater(blockId, 0);
        }

        [TearDown]
        public void TearDown()
        {
            if (composerObject != null)
                Object.DestroyImmediate(composerObject);
        }
    }
}
