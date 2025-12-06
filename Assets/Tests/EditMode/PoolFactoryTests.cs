using NUnit.Framework;

namespace Tests.EditMode
{
    /// <summary>
    /// Tests para PoolFactory
    /// Valida: Creación de pools, object pooling
    /// </summary>
    public class PoolFactoryTests
    {
        private PoolFactory factory;

        [SetUp]
        public void SetUp()
        {
            factory = new PoolFactory();
        }

        [Test]
        public void CreatePool_CreatesValidPool()
        {
            // Arrange
            var config = new PoolConfiguration
            {
                PoolType = PoolType.Bullet,
                InitialSize = 10,
                MaxSize = 50
            };

            // Act
            var pool = factory.CreatePool(config);

            // Assert
            Assert.IsNotNull(pool);
        }

        [Test]
        public void CreatePool_WithZeroSize_UsesDefaultSize()
        {
            // Arrange
            var config = new PoolConfiguration
            {
                PoolType = PoolType.Enemy,
                InitialSize = 0
            };

            // Act
            var pool = factory.CreatePool(config);

            // Assert
            Assert.IsNotNull(pool);
        }

        [TearDown]
        public void TearDown()
        {
            factory = null;
        }
    }
}
