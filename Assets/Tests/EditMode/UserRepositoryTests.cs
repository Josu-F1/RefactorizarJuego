using NUnit.Framework;
using UnityEngine;

namespace Tests.EditMode
{
    /// <summary>
    /// Tests para UserRepository
    /// Valida: Creación, validación y gestión de usuarios
    /// </summary>
    public class UserRepositoryTests
    {
        private UserRepository repository;
        private MockPersistenceProvider mockProvider;

        [SetUp]
        public void SetUp()
        {
            mockProvider = new MockPersistenceProvider();
            repository = new UserRepository(mockProvider);
        }

        [Test]
        public void UserExists_ForNewUser_ReturnsFalse()
        {
            // Act
            bool exists = repository.UserExists("NewUser");

            // Assert
            Assert.IsFalse(exists);
        }

        [Test]
        public void CreateUser_CreatesNewUser()
        {
            // Arrange
            string username = "TestUser";

            // Act
            repository.CreateUser(username);

            // Assert
            bool exists = repository.UserExists(username);
            Assert.IsTrue(exists);
        }

        [Test]
        public void ValidateUser_ForExistingUser_ReturnsTrue()
        {
            // Arrange
            string username = "ValidUser";
            repository.CreateUser(username);

            // Act
            bool isValid = repository.ValidateUser(username);

            // Assert
            Assert.IsTrue(isValid);
        }

        [Test]
        public void ValidateUser_ForNonExistingUser_ReturnsFalse()
        {
            // Act
            bool isValid = repository.ValidateUser("NonExistent");

            // Assert
            Assert.IsFalse(isValid);
        }

        [Test]
        public void GetRecentUsernames_ReturnsCorrectCount()
        {
            // Arrange
            repository.AddRecentUsername("User1");
            repository.AddRecentUsername("User2");
            repository.AddRecentUsername("User3");

            // Act
            string[] recent = repository.GetRecentUsernames(2);

            // Assert
            Assert.AreEqual(2, recent.Length);
        }

        [TearDown]
        public void TearDown()
        {
            repository = null;
            mockProvider = null;
        }
    }
}
