using NUnit.Framework;
using UnityEngine;

namespace Tests.EditMode
{
    /// <summary>
    /// Tests para ProgressRepository
    /// Valida: Operaciones de persistencia de progreso
    /// </summary>
    public class ProgressRepositoryTests
    {
        private ProgressRepository repository;
        private MockPersistenceProvider mockProvider;

        [SetUp]
        public void SetUp()
        {
            mockProvider = new MockPersistenceProvider();
            repository = new ProgressRepository(mockProvider);
        }

        [Test]
        public void GetPlayerLevel_ForNewUser_ReturnsZero()
        {
            // Act
            int level = repository.GetPlayerLevel("NewUser");

            // Assert
            Assert.AreEqual(0, level);
        }

        [Test]
        public void SavePlayerLevel_StoresCorrectValue()
        {
            // Arrange
            string username = "TestUser";
            int level = 10;

            // Act
            repository.SavePlayerLevel(username, level);

            // Assert
            int savedLevel = repository.GetPlayerLevel(username);
            Assert.AreEqual(level, savedLevel);
        }

        [Test]
        public void SavePlayerLevel_WithNegativeLevel_DoesNotSave()
        {
            // Arrange
            string username = "TestUser";

            // Act
            repository.SavePlayerLevel(username, -5);

            // Assert
            int level = repository.GetPlayerLevel(username);
            Assert.AreEqual(0, level, "No debe guardar niveles negativos");
        }

        [Test]
        public void ResetProgress_SetsLevelToZero()
        {
            // Arrange
            string username = "TestUser";
            repository.SavePlayerLevel(username, 15);

            // Act
            repository.ResetProgress(username);

            // Assert
            int level = repository.GetPlayerLevel(username);
            Assert.AreEqual(0, level);
        }

        [TearDown]
        public void TearDown()
        {
            repository = null;
            mockProvider = null;
        }
    }

    /// <summary>
    /// Mock del proveedor de persistencia para testing
    /// </summary>
    public class MockPersistenceProvider : IPersistenceProvider
    {
        private System.Collections.Generic.Dictionary<string, int> intData = 
            new System.Collections.Generic.Dictionary<string, int>();

        public void SetInt(string key, int value)
        {
            intData[key] = value;
        }

        public int GetInt(string key, int defaultValue)
        {
            return intData.ContainsKey(key) ? intData[key] : defaultValue;
        }

        public void SetFloat(string key, float value) { }
        public float GetFloat(string key, float defaultValue) { return defaultValue; }
        public void SetString(string key, string value) { }
        public string GetString(string key, string defaultValue) { return defaultValue; }
        public void DeleteKey(string key) 
        { 
            if (intData.ContainsKey(key))
                intData.Remove(key);
        }
        public bool HasKey(string key) { return intData.ContainsKey(key); }
        public void Save() { }
    }
}
