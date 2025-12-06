using NUnit.Framework;
using UnityEngine;

namespace Tests.EditMode
{
    /// <summary>
    /// Tests para VFXEffectFactory
    /// Valida: Registro de prefabs, creación de efectos
    /// </summary>
    public class VFXFactoryTests
    {
        private VFXEffectFactory factory;
        private GameObject testPrefab;

        [SetUp]
        public void SetUp()
        {
            factory = new VFXEffectFactory();
            testPrefab = new GameObject("TestVFX");
        }

        [Test]
        public void RegisterPrefab_AddsEffectToFactory()
        {
            // Act
            factory.RegisterPrefab(VFXEffectType.FloatingText, testPrefab);

            // Assert
            Assert.IsTrue(factory.HasPrefab(VFXEffectType.FloatingText));
        }

        [Test]
        public void CreateEffect_WithRegisteredPrefab_ReturnsInstance()
        {
            // Arrange
            factory.RegisterPrefab(VFXEffectType.FloatingText, testPrefab);

            // Act
            var instance = factory.CreateEffect(VFXEffectType.FloatingText, Vector3.zero);

            // Assert
            Assert.IsNotNull(instance);
            
            // Cleanup
            if (instance != null)
                Object.DestroyImmediate(instance);
        }

        [Test]
        public void CreateEffect_WithoutRegisteredPrefab_ReturnsNull()
        {
            // Act
            var instance = factory.CreateEffect(VFXEffectType.ColorFlash, Vector3.zero);

            // Assert
            Assert.IsNull(instance);
        }

        [TearDown]
        public void TearDown()
        {
            if (testPrefab != null)
                Object.DestroyImmediate(testPrefab);
            factory = null;
        }
    }
}
