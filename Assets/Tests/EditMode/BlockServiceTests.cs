using NUnit.Framework;

namespace Tests.EditMode
{
    /// <summary>
    /// Tests para BlockService (Clean Architecture)
    /// Valida: Gestión de bloques
    /// </summary>
    public class BlockServiceTests
    {
        private BlockService blockService;

        [SetUp]
        public void SetUp()
        {
            blockService = new BlockService();
        }

        [Test]
        public void CreateBlock_CreatesNewBlock()
        {
            // Act
            var blockId = blockService.CreateBlock(BlockType.Brick);

            // Assert
            Assert.Greater(blockId, 0);
        }

        [Test]
        public void DestroyBlock_RemovesBlock()
        {
            // Arrange
            var blockId = blockService.CreateBlock(BlockType.Brick);

            // Act
            blockService.DestroyBlock(blockId);

            // Assert
            Assert.IsFalse(blockService.BlockExists(blockId));
        }

        [Test]
        public void GetBlockCount_ReturnsCorrectCount()
        {
            // Arrange
            blockService.CreateBlock(BlockType.Brick);
            blockService.CreateBlock(BlockType.Metal);

            // Act
            int count = blockService.GetBlockCount();

            // Assert
            Assert.AreEqual(2, count);
        }

        [TearDown]
        public void TearDown()
        {
            blockService = null;
        }
    }
}
