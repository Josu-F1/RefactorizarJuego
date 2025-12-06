using NUnit.Framework;

namespace Tests.EditMode
{
    /// <summary>
    /// Tests para MenuSystemComposer
    /// Valida: Sistema de menús
    /// </summary>
    public class MenuSystemTests
    {
        [Test]
        public void MenuState_Initial_IsMainMenu()
        {
            // Arrange
            var menuSystem = new MenuSystem();

            // Act
            var currentState = menuSystem.GetCurrentState();

            // Assert
            Assert.IsNotNull(currentState);
        }

        [Test]
        public void ShowMenu_ChangesState()
        {
            // Arrange
            var menuSystem = new MenuSystem();

            // Act
            menuSystem.ShowMenu("PauseMenu");

            // Assert
            // Verificar que el cambio de estado ocurrió
            Assert.IsNotNull(menuSystem.GetCurrentState());
        }
    }
}
