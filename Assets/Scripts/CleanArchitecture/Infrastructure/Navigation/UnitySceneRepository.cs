using CleanArchitecture.Domain.Navigation;
using UnityEngine.SceneManagement;

/// <summary>
/// Implementación que usa SceneManager directamente.
/// </summary>
namespace CleanArchitecture.Infrastructure.Navigation
{
    public class UnitySceneRepository : INavRepository
    {
        public void Load(SceneId scene)
        {
            if (!scene.IsValid) return;
            SceneManager.LoadScene(scene.Name);
        }

        public void ReloadCurrent()
        {
            var active = SceneManager.GetActiveScene();
            SceneManager.LoadScene(active.name);
        }
    }
}
