using NUnit.Framework;
using CleanArchitecture.Infrastructure.Services;

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
        public void BlockService_CanBeInstantiated()
        {
            // Assert
            Assert.IsNotNull(blockService, "BlockService should be instantiated");
        }

        [TearDown]
        public void TearDown()
        {
            blockService = null;
        }
    }
}
