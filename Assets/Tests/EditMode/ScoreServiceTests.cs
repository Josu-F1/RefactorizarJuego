using NUnit.Framework;

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
            scoreService = new ScoreService(requiredScore: 200);
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
        public void ResetScore_SetsScoreToZero()
        {
            // Arrange
            scoreService.AddScore(150);

            // Act
            scoreService.ResetScore();

            // Assert
            Assert.AreEqual(0, scoreService.CurrentScore);
        }

        [Test]
        public void Progress_CalculatesCorrectly()
        {
            // Arrange
            scoreService.AddScore(100); // 100/200 = 0.5

            // Act
            float progress = scoreService.Progress;

            // Assert
            Assert.AreEqual(0.5f, progress, 0.01f);
        }

        [Test]
        public void IsGoalReached_WhenScoreReachesRequired_ReturnsTrue()
        {
            // Arrange
            scoreService.AddScore(200);

            // Act
            bool goalReached = scoreService.IsGoalReached;

            // Assert
            Assert.IsTrue(goalReached);
        }

        [TearDown]
        public void TearDown()
        {
            scoreService = null;
        }
    }
}
