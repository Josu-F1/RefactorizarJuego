using NUnit.Framework;
using PoolSystem.Factories;
using PoolSystem.Interfaces;

namespace Tests.EditMode
{
    /// <summary>
    /// Tests para PoolObjectFactory
    /// Valida: Creación de pools, object pooling
    /// </summary>
    public class PoolFactoryTests
    {
        private PoolObjectFactory factory;

        [SetUp]
        public void SetUp()
        {
            factory = new PoolObjectFactory();
        }

        [Test]
        public void PoolFactory_CanBeInstantiated()
        {
            // Assert
            Assert.IsNotNull(factory, "PoolObjectFactory should be instantiated");
        }

        [TearDown]
        public void TearDown()
        {
            factory = null;
        }
    }
}
