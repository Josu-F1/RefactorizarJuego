using NUnit.Framework;
using UnityEngine;

namespace Tests.EditMode
{
    /// <summary>
    /// Tests para CharacterController y CharacterControllerFactory
    /// Valida: Creación, registro de componentes, eventos
    /// </summary>
    public class CharacterControllerTests
    {
        private GameObject testGameObject;
        private CharacterController controller;

        [SetUp]
        public void SetUp()
        {
            testGameObject = new GameObject("TestCharacter");
        }

        [Test]
        public void CreateController_WithPlayerType_CreatesPlayerController()
        {
            // Act
            controller = CharacterControllerFactory.CreateCharacterController(
                CharacterType.Player, 
                testGameObject
            );

            // Assert
            Assert.IsNotNull(controller);
        }

        [Test]
        public void RegisterComponent_AddsComponentToController()
        {
            // Arrange
            controller = new CharacterController(CharacterType.Player, testGameObject, null);
            var mockComponent = new MockDeathHandler();

            // Act
            controller.RegisterComponent<IDeathHandler>(mockComponent);

            // Assert
            var retrieved = controller.GetComponent<IDeathHandler>();
            Assert.IsNotNull(retrieved);
            Assert.AreEqual(mockComponent, retrieved);
        }

        [Test]
        public void Cleanup_RemovesAllComponents()
        {
            // Arrange
            controller = new CharacterController(CharacterType.Player, testGameObject, null);
            controller.RegisterComponent<IDeathHandler>(new MockDeathHandler());

            // Act
            controller.Cleanup();

            // Assert
            var component = controller.GetComponent<IDeathHandler>();
            Assert.IsNull(component);
        }

        [TearDown]
        public void TearDown()
        {
            if (testGameObject != null)
                Object.DestroyImmediate(testGameObject);
        }
    }

    public class MockDeathHandler : IDeathHandler
    {
        public bool HandleDeathCalled = false;
        public void Initialize(ICharacterController controller) { }
        public void HandleDeath() { HandleDeathCalled = true; }
    }
}
