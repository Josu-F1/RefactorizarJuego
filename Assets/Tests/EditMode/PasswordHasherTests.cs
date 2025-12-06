using NUnit.Framework;
using UnityEngine;

namespace Tests.EditMode
{
    /// <summary>
    /// Tests para PasswordHasher
    /// Valida: Encriptación y verificación de contraseñas
    /// </summary>
    public class PasswordHasherTests
    {
        private IPasswordHasher hasher;

        [SetUp]
        public void SetUp()
        {
            hasher = PasswordHasherFactory.CreateDefaultHasher();
        }

        [Test]
        public void HashPassword_CreatesNonEmptyHash()
        {
            // Act
            string hash = hasher.HashPassword("TestPassword123");

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(hash));
        }

        [Test]
        public void HashPassword_SamePassword_CreatesDifferentHashes()
        {
            // Act
            string hash1 = hasher.HashPassword("Password123");
            string hash2 = hasher.HashPassword("Password123");

            // Assert
            Assert.AreNotEqual(hash1, hash2, "Los hashes deben ser diferentes debido al salt");
        }

        [Test]
        public void VerifyPassword_WithCorrectPassword_ReturnsTrue()
        {
            // Arrange
            string password = "SecurePass456";
            string hash = hasher.HashPassword(password);

            // Act
            bool isValid = hasher.VerifyPassword(password, hash);

            // Assert
            Assert.IsTrue(isValid);
        }

        [Test]
        public void VerifyPassword_WithIncorrectPassword_ReturnsFalse()
        {
            // Arrange
            string password = "CorrectPassword";
            string hash = hasher.HashPassword(password);

            // Act
            bool isValid = hasher.VerifyPassword("WrongPassword", hash);

            // Assert
            Assert.IsFalse(isValid);
        }

        [Test]
        public void VerifyPassword_WithEmptyPassword_ReturnsFalse()
        {
            // Arrange
            string hash = hasher.HashPassword("SomePassword");

            // Act
            bool isValid = hasher.VerifyPassword("", hash);

            // Assert
            Assert.IsFalse(isValid);
        }

        [TearDown]
        public void TearDown()
        {
            hasher = null;
        }
    }
}
