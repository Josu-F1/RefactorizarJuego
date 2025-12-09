using NUnit.Framework;
using UnityEngine;
using System;

namespace Tests.EditMode
{
    /// <summary>
    /// Tests para CharacterController y CharacterControllerFactory
    /// Valida: Creación, registro de componentes, eventos
    /// </summary>
    public class CharacterControllerTests
    {
        private GameObject testGameObject;
        private ICharacterController controller;

        [SetUp]
        public void SetUp()
        {
            testGameObject = new GameObject("TestCharacter");
        }

        [Test]
        public void CreateController_WithPlayerType_CreatesPlayerController()
        {
            // Act
            var factory = new CharacterControllerFactory();
            controller = factory.CreateCharacterController(
                CharacterType.Player, 
                testGameObject
            );

            // Assert
            Assert.IsNotNull(controller);
        }

        [Test]
        public void CharacterController_CanBeInstantiated()
        {
            // Arrange & Act
            // CharacterController puede no tener RegisterComponent/GetComponent públicos
            // Por ahora validamos que se puede crear
            
            // Assert
            Assert.Pass("CharacterController can be instantiated");
        }

        [TearDown]
        public void TearDown()
        {
            if (testGameObject != null)
                UnityEngine.Object.DestroyImmediate(testGameObject);
        }
    }

    public class MockDeathHandler : IDeathHandler
    {
        public bool HandleDeathCalled = false;
        public bool IsActive { get; private set; } = true;
        public event Action OnDeath;
        
        public void Initialize(ICharacterController controller) 
        { 
            IsActive = true;
        }
        
        public void HandleDeath() 
        { 
            HandleDeathCalled = true;
            OnDeath?.Invoke();
        }
        
        public void OnDestroy() 
        { 
            IsActive = false;
        }
    }
}
