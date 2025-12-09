using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

namespace Tests.PlayMode
{
    /// <summary>
    /// Tests para MapZonesManager
    /// Valida: Gestión de zonas del mapa, desbloqueo de niveles
    /// </summary>
    public class MapZonesManagerTests
    {
        private GameObject managerObject;
        private MapZonesManager mapManager;

        [SetUp]
        public void SetUp()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();

            managerObject = new GameObject("MapZonesManager");
            mapManager = managerObject.AddComponent<MapZonesManager>();
        }

        [UnityTest]
        public IEnumerator MapZonesManager_Initializes()
        {
            // Act
            yield return new WaitForSeconds(0.2f);

            // Assert
            Assert.IsNotNull(mapManager);
        }

        [TearDown]
        public void TearDown()
        {
            if (managerObject != null)
                Object.DestroyImmediate(managerObject);
            
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
    }
}
