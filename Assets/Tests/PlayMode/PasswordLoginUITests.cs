using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

namespace Tests.PlayMode
{
    /// <summary>
    /// Tests para PasswordLoginUI
    /// Valida: UI de login con contraseñas
    /// </summary>
    public class PasswordLoginUITests
    {
        private GameObject uiObject;
        private PasswordLoginUI loginUI;

        [SetUp]
        public void SetUp()
        {
            uiObject = new GameObject("LoginUI");
            loginUI = uiObject.AddComponent<PasswordLoginUI>();
        }

        [UnityTest]
        public IEnumerator LoginUI_Initializes()
        {
            // Act
            yield return new WaitForSeconds(0.2f);

            // Assert
            Assert.IsNotNull(loginUI);
        }

        [TearDown]
        public void TearDown()
        {
            if (uiObject != null)
                Object.DestroyImmediate(uiObject);
        }
    }
}
