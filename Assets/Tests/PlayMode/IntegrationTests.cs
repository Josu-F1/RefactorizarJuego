using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

namespace Tests.PlayMode
{
    /// <summary>
    /// Tests de integración para el flujo completo del juego
    /// Valida: Login → Juego → Progreso guardado
    /// </summary>
    public class IntegrationTests
    {
        [SetUp]
        public void SetUp()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }

        [UnityTest]
        public IEnumerator FullFlow_Login_SaveProgress_LoadProgress()
        {
            // Arrange
            string username = "IntegrationTestUser";
            
            // Act 1: Login
            DataManagerComposer.SaveUsername(username);
            DataManagerComposer.CurrentUsername = username;
            
            yield return new WaitForSeconds(0.1f);

            // Act 2: Simular completar nivel
            DataManagerComposer.SavePlayerLevel(username, 3);
            
            yield return new WaitForSeconds(0.1f);

            // Act 3: Cargar progreso
            int savedLevel = DataManagerComposer.GetPlayerLevel(username);

            // Assert
            Assert.AreEqual(3, savedLevel, "El progreso debe guardarse y cargarse correctamente");
            Assert.IsTrue(DataManagerComposer.UsernameExists(username), "El usuario debe existir");
        }

        [UnityTest]
        public IEnumerator FullFlow_MultipleUsers_IndependentProgress()
        {
            // Arrange
            string user1 = "User1";
            string user2 = "User2";

            // Act
            DataManagerComposer.SavePlayerLevel(user1, 5);
            DataManagerComposer.SavePlayerLevel(user2, 10);
            
            yield return new WaitForSeconds(0.1f);

            // Assert
            Assert.AreEqual(5, DataManagerComposer.GetPlayerLevel(user1));
            Assert.AreEqual(10, DataManagerComposer.GetPlayerLevel(user2));
        }

        [TearDown]
        public void TearDown()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
    }
}
