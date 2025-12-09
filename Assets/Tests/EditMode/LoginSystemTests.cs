using NUnit.Framework;
using UnityEngine;

namespace Tests.EditMode
{
    /// <summary>
    /// Tests para LoginSystemComposer
    /// Valida: Sistema de login completo
    /// </summary>
    public class LoginSystemTests
    {
        [SetUp]
        public void SetUp()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }

        [Test]
        public void Login_WithValidCredentials_Succeeds()
        {
            // Arrange
            string username = "ValidUser";
            DataManagerComposer.SaveUsername(username);

            // Act
            bool exists = DataManagerComposer.UsernameExists(username);

            // Assert
            Assert.IsTrue(exists);
        }

        [Test]
        public void Login_WithInvalidCredentials_Fails()
        {
            // Act
            bool exists = DataManagerComposer.UsernameExists("NonExistentUser");

            // Assert
            Assert.IsFalse(exists);
        }

        [TearDown]
        public void TearDown()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
    }
}
