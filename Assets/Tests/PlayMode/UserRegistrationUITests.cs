using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

namespace Tests.PlayMode
{
    /// <summary>
    /// Tests para UserRegistrationUI
    /// Valida: UI de registro de usuarios
    /// </summary>
    public class UserRegistrationUITests
    {
        private GameObject uiObject;
        private UserRegistrationUI registrationUI;

        [SetUp]
        public void SetUp()
        {
            uiObject = new GameObject("RegistrationUI");
            registrationUI = uiObject.AddComponent<UserRegistrationUI>();
        }

        [UnityTest]
        public IEnumerator RegistrationUI_Initializes()
        {
            // Act
            yield return new WaitForSeconds(0.2f);

            // Assert
            Assert.IsNotNull(registrationUI);
        }

        [TearDown]
        public void TearDown()
        {
            if (uiObject != null)
                Object.DestroyImmediate(uiObject);
        }
    }
}
