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
        private MockPersistenceProvider mockProvider;

        [SetUp]
        public void SetUp()
        {
            mockProvider = new MockPersistenceProvider();
            userRepository = new UserRepository(mockProvider);
            progressRepository = new ProgressRepository(mockProvider);
            progressSystem = new ProgressSystem(progressRepository);
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
            mockProvider = null;
        }
    }
}
