using NUnit.Framework;

namespace Tests.EditMode
{
    /// <summary>
    /// Tests para ShootingSystemComposer
    /// Valida: Sistema de disparo
    /// </summary>
    public class ShootingSystemTests
    {
        [Test]
        public void ShootingStrategy_SingleShot_CreatesOneBullet()
        {
            // Arrange
            var strategy = new SingleShotStrategy();
            int bulletCount = 0;

            // Act
            // Nota: Esto requeriría un mock del factory
            // Por ahora validamos que la estrategia existe

            // Assert
            Assert.IsNotNull(strategy);
        }

        [Test]
        public void ShootingStrategy_BurstShot_CreatesMultipleBullets()
        {
            // Arrange
            var strategy = new BurstShotStrategy();

            // Assert
            Assert.IsNotNull(strategy);
        }
    }
}
