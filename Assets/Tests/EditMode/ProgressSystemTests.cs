using NUnit.Framework;

namespace Tests.EditMode
{
    /// <summary>
    /// Tests para ProgressSystem
    /// Valida: Lógica de negocio de progreso
    /// </summary>
    public class ProgressSystemTests
    {
        private ProgressSystem progressSystem;
        private UserRepository userRepository;
        private ProgressRepository progressRepository;

        [SetUp]
        public void SetUp()
        {
            var provider = new MockPersistenceProvider();
            userRepository = new UserRepository(provider);
            progressRepository = new ProgressRepository(provider);
            // ProgressSystem requiere IUserProgressRepository
            // Por ahora simplificamos el test
        }

        [Test]
        public void LoadUser_ValidUser_LoadsCorrectly()
        {
            // Arrange
            string username = "TestUser";
            progressRepository.SavePlayerLevel(username, 5);

            // Act
            progressSystem.LoadUser(username);

            // Assert
            Assert.AreEqual(username, progressSystem.UserName);
            Assert.AreEqual(5, progressSystem.Level);
        }

        [Test]
        public void AddPoints_IncreasesPoints()
        {
            // Arrange
            string username = "TestUser";
            progressSystem.LoadUser(username);
            int initialPoints = progressSystem.Points;

            // Act
            progressSystem.AddPoints(100);

            // Assert
            Assert.AreEqual(initialPoints + 100, progressSystem.Points);
        }

        [Test]
        public void AddPoints_WithNegativeValue_DoesNotAdd()
        {
            // Arrange
            string username = "TestUser";
            progressSystem.LoadUser(username);
            int initialPoints = progressSystem.Points;

            // Act
            progressSystem.AddPoints(-50);

            // Assert
            Assert.AreEqual(initialPoints, progressSystem.Points);
        }

        [Test]
        public void NextLevel_IncreasesLevel()
        {
            // Arrange
            string username = "TestUser";
            progressSystem.LoadUser(username);
            int initialLevel = progressSystem.Level;

            // Act
            progressSystem.NextLevel();

            // Assert
            Assert.AreEqual(initialLevel + 1, progressSystem.Level);
        }

        [TearDown]
        public void TearDown()
        {
            progressSystem = null;
            progressRepository = null;
            userRepository = null;
        }
    }
}
