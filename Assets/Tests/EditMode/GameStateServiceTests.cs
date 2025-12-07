using NUnit.Framework;
using CleanArchitecture.Infrastructure.Services;

namespace Tests.EditMode
{
    /// <summary>
    /// Tests para GameStateService (Clean Architecture)
    /// Valida: Estados del juego, victoria, derrota
    /// </summary>
    public class GameStateServiceTests
    {
        private GameStateService gameStateService;
        private bool victoryTriggered;
        private bool defeatTriggered;

        [SetUp]
        public void SetUp()
        {
            gameStateService = new GameStateService(endGameDelay: 0.1f);
            victoryTriggered = false;
            defeatTriggered = false;

            gameStateService.OnVictory += () => victoryTriggered = true;
            gameStateService.OnDefeat += () => defeatTriggered = true;
        }

        [Test]
        public void TriggerVictory_RaisesVictoryEvent()
        {
            // Act
            gameStateService.TriggerVictory();

            // Assert
            Assert.IsTrue(victoryTriggered);
        }

        [Test]
        public void TriggerDefeat_RaisesDefeatEvent()
        {
            // Act
            gameStateService.TriggerDefeat();

            // Assert
            Assert.IsTrue(defeatTriggered);
        }

        [Test]
        public void IsPlaying_InitiallyTrue()
        {
            // Assert
            Assert.IsTrue(gameStateService.IsPlaying);
        }

        [Test]
        public void TriggerVictory_SetsIsPlayingToFalse()
        {
            // Act
            gameStateService.TriggerVictory();

            // Assert
            Assert.IsFalse(gameStateService.IsPlaying);
        }

        [TearDown]
        public void TearDown()
        {
            gameStateService = null;
        }
    }
}
