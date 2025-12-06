using NUnit.Framework;
using UnityEngine;

namespace Tests.EditMode
{
    /// <summary>
    /// Tests para el sistema de persistencia DataManagerComposer
    /// Valida: Guardado, carga, verificación de progreso
    /// </summary>
    public class DataManagerTests
    {
        [SetUp]
        public void SetUp()
        {
            // Limpiar PlayerPrefs antes de cada test
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }

        [Test]
        public void SavePlayerLevel_StoresCorrectValue()
        {
            // Arrange
            string username = "TestPlayer";
            int level = 5;

            // Act
            DataManagerComposer.SavePlayerLevel(username, level);

            // Assert
            int savedLevel = DataManagerComposer.GetPlayerLevel(username);
            Assert.AreEqual(level, savedLevel, "El nivel guardado debe coincidir con el nivel establecido");
        }

        [Test]
        public void GetPlayerLevel_ForNewUser_ReturnsZero()
        {
            // Act
            int level = DataManagerComposer.GetPlayerLevel("NewUser");

            // Assert
            Assert.AreEqual(0, level, "Un usuario nuevo debe tener nivel 0");
        }

        [Test]
        public void SavePlayerLevel_OverwritesPreviousValue()
        {
            // Arrange
            string username = "TestPlayer";
            DataManagerComposer.SavePlayerLevel(username, 3);

            // Act
            DataManagerComposer.SavePlayerLevel(username, 7);

            // Assert
            int level = DataManagerComposer.GetPlayerLevel(username);
            Assert.AreEqual(7, level, "El nivel debe actualizarse al nuevo valor");
        }

        [Test]
        public void CurrentUsername_WhenNotSet_ReturnsEmpty()
        {
            // Act
            string user = DataManagerComposer.CurrentUsername;

            // Assert
            Assert.IsTrue(string.IsNullOrEmpty(user), "El usuario actual debe estar vacío si no se ha establecido");
        }

        [Test]
        public void CurrentUsername_SavesAndRetrievesUsername()
        {
            // Arrange
            string username = "SessionUser";

            // Act
            DataManagerComposer.CurrentUsername = username;

            // Assert
            string retrieved = DataManagerComposer.CurrentUsername;
            Assert.AreEqual(username, retrieved, "El nombre de usuario debe guardarse correctamente");
        }

        [Test]
        public void UsernameExists_ForNewUser_ReturnsFalse()
        {
            // Act
            bool exists = DataManagerComposer.UsernameExists("NonExistentUser");

            // Assert
            Assert.IsFalse(exists, "Un usuario que no existe debe retornar false");
        }

        [Test]
        public void UsernameExists_AfterSaving_ReturnsTrue()
        {
            // Arrange
            string username = "ExistingUser";
            DataManagerComposer.SaveUsername(username);

            // Act
            bool exists = DataManagerComposer.UsernameExists(username);

            // Assert
            Assert.IsTrue(exists, "Un usuario guardado debe existir");
        }

        [TearDown]
        public void TearDown()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
    }
}
