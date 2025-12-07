using NUnit.Framework;
using CleanArchitecture.Infrastructure.Services;

namespace Tests.EditMode
{
    /// <summary>
    /// Tests para ScoreService (Clean Architecture)
    /// Valida: Gestión de puntuación
    /// </summary>
    public class ScoreServiceTests
    {
        private ScoreService scoreService;

        [SetUp]
        public void SetUp()
        {
            scoreService = new ScoreService();
        }

        [Test]
        public void AddScore_IncreasesCurrentScore()
        {
            // Arrange
            int initialScore = scoreService.CurrentScore;

            // Act
            scoreService.AddScore(50);

            // Assert
            Assert.AreEqual(initialScore + 50, scoreService.CurrentScore);
        }

        [Test]
        public void AddScore_WithNegativeValue_DoesNotDecrease()
        {
            // Arrange
            scoreService.AddScore(100);
            int currentScore = scoreService.CurrentScore;

            // Act
            scoreService.AddScore(-50);

            // Assert
            Assert.AreEqual(currentScore, scoreService.CurrentScore);
        }

        [Test]
        public void ScoreService_CanBeInstantiated()
        {
            // Assert
            Assert.IsNotNull(scoreService, "ScoreService should be instantiated");
        }

        [TearDown]
        public void TearDown()
        {
            scoreService = null;
        }
    }
}
