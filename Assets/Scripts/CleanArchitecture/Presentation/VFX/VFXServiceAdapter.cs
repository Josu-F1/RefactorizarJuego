using UnityEngine;
using CleanArchitecture.Application.VFX;
using CleanArchitecture.Infrastructure.VFX;

namespace CleanArchitecture.Presentation.VFX
{
    /// <summary>
    /// MonoBehaviour opcional para disparar efectos usando VFXService.
    /// </summary>
    public class VFXServiceAdapter : MonoBehaviour
    {
        // Usamos Object genérico para no depender del tipo concreto de factory legacy.
        [SerializeField] private Object vfxFactoryObject;

        private VFXService service;

        private void Awake()
        {
            if (vfxFactoryObject == null)
            {
                // Buscar cualquier componente cuyo nombre contenga "VFXFactory"
                var candidates = FindObjectsOfType<MonoBehaviour>();
                foreach (var mb in candidates)
                {
                    if (mb.GetType().Name.Contains("VFXFactory"))
                    {
                        vfxFactoryObject = mb;
                        break;
                    }
                }
            }

            if (vfxFactoryObject != null)
            {
                var repo = new VFXFactoryRepository(vfxFactoryObject);
                service = new VFXService(repo);
            }
        }

        public GameObject Spawn(string effectId, Vector3 position)
        {
            return service?.Spawn(effectId, position);
        }
    }
}
