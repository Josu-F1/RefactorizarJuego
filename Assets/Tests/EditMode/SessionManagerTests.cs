using NUnit.Framework;
using UnityEngine;

namespace Tests.EditMode
{
    /// <summary>
    /// Tests para SessionManager
    /// Valida: Gestión de sesión de usuario
    /// </summary>
    public class SessionManagerTests
    {
        private SessionManager sessionManager;

        [SetUp]
        public void SetUp()
        {
            sessionManager = new SessionManager();
        }

        [Test]
        public void HasActiveSession_Initially_ReturnsFalse()
        {
            // Assert
            Assert.IsFalse(sessionManager.HasActiveSession);
        }

        [Test]
        public void StartSession_SetsActiveSession()
        {
            // Act
            sessionManager.StartSession("TestUser");

            // Assert
            Assert.IsTrue(sessionManager.HasActiveSession);
            Assert.AreEqual("TestUser", sessionManager.CurrentUsername);
        }

        [Test]
        public void StartSession_WithEmptyUsername_DoesNotStart()
        {
            // Act
            sessionManager.StartSession("");

            // Assert
            Assert.IsFalse(sessionManager.HasActiveSession);
        }

        [Test]
        public void EndSession_ClearsActiveSession()
        {
            // Arrange
            sessionManager.StartSession("TestUser");

            // Act
            sessionManager.EndSession();

            // Assert
            Assert.IsFalse(sessionManager.HasActiveSession);
        }

        [Test]
        public void CurrentUsername_CanBeSetDirectly()
        {
            // Act
            sessionManager.CurrentUsername = "DirectUser";

            // Assert
            Assert.AreEqual("DirectUser", sessionManager.CurrentUsername);
        }

        [TearDown]
        public void TearDown()
        {
            sessionManager = null;
        }
    }
}
