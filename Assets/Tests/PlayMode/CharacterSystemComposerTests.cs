using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

namespace Tests.PlayMode
{
    /// <summary>
    /// Tests para CharacterSystemComposer
    /// Valida: Creación de controladores de personajes
    /// </summary>
    public class CharacterSystemComposerTests
    {
        private GameObject composerObject;
        private CharacterSystemComposer composer;
        private GameObject characterObject;

        [SetUp]
        public void SetUp()
        {
            // Limpiar instancia anterior
            if (CharacterSystemComposer.Instance != null)
            {
                Object.DestroyImmediate(CharacterSystemComposer.Instance.gameObject);
            }

            composerObject = new GameObject("CharacterSystemComposer");
            composer = composerObject.AddComponent<CharacterSystemComposer>();
        }

        [UnityTest]
        public IEnumerator CreateCharacterController_ForPlayer_ReturnsController()
        {
            // Arrange
            characterObject = new GameObject("TestPlayer");
            yield return new WaitForSeconds(0.2f);

            // Act
            var controller = composer.CreateCharacterController(CharacterType.Player, characterObject);

            // Assert
            Assert.IsNotNull(controller, "Debe crear un controlador de personaje");
        }

        [UnityTest]
        public IEnumerator CreateCharacterController_RegistersController()
        {
            // Arrange
            characterObject = new GameObject("TestEnemy");
            yield return new WaitForSeconds(0.2f);

            // Act
            var controller = composer.CreateCharacterController(CharacterType.Enemy, characterObject);
            var retrieved = composer.GetCharacterController(characterObject);

            // Assert
            Assert.IsNotNull(retrieved);
            Assert.AreEqual(controller, retrieved);
        }

        [TearDown]
        public void TearDown()
        {
            if (characterObject != null)
                Object.DestroyImmediate(characterObject);
            if (composerObject != null)
                Object.DestroyImmediate(composerObject);
        }
    }
}
