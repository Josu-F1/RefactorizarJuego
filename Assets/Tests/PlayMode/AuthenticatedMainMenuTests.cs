using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

namespace Tests.PlayMode
{
    /// <summary>
    /// Tests para AuthenticatedMainMenu
    /// Valida: Menú principal autenticado
    /// </summary>
    public class AuthenticatedMainMenuTests
    {
        private GameObject menuObject;
        private AuthenticatedMainMenu mainMenu;

        [SetUp]
        public void SetUp()
        {
            menuObject = new GameObject("MainMenu");
            mainMenu = menuObject.AddComponent<AuthenticatedMainMenu>();
        }

        [UnityTest]
        public IEnumerator MainMenu_Initializes()
        {
            // Act
            yield return new WaitForSeconds(0.2f);

            // Assert
            Assert.IsNotNull(mainMenu);
        }

        [TearDown]
        public void TearDown()
        {
            if (menuObject != null)
                Object.DestroyImmediate(menuObject);
        }
    }
}
