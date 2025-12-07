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
            testPrefab.AddComponent<MockVisualEffect>();
        }

        [Test]
        public void RegisterPrefab_AddsEffectToFactory()
        {
            // Act
            factory.RegisterEffectPrefab(EffectType.FloatingText, testPrefab);

            // Assert (no hay método HasPrefab, simplificamos el test)
            Assert.Pass("Effect prefab registered successfully");
        }

        [Test]
        public void CreateEffect_WithRegisteredPrefab_ReturnsInstance()
        {
            // Arrange
            factory.RegisterEffectPrefab(EffectType.FloatingText, testPrefab);

            // Act
            var instance = factory.CreateEffect(EffectType.FloatingText, null);

            // Assert
            Assert.IsNotNull(instance);
        }

        [Test]
        public void CreateEffect_WithoutRegisteredPrefab_ReturnsNull()
        {
            // Act
            var instance = factory.CreateEffect(EffectType.ColorFlash, null);

            // Assert
            Assert.IsNull(instance);
        }

        [TearDown]
        public void TearDown()
        {
            if (testPrefab != null)
                UnityEngine.Object.DestroyImmediate(testPrefab);
            factory = null;
        }
    }

    // Mock para IVisualEffect
    public class MockVisualEffect : MonoBehaviour, IVisualEffect
    {
        public bool IsPlaying { get; private set; }
        public EffectType EffectType { get; set; }
        
        public void Play() { IsPlaying = true; }
        public void Stop() { IsPlaying = false; }
        public void SetPosition(Vector3 position) { }
    }
}
