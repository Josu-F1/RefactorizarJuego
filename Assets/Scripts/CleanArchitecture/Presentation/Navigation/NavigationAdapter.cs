using UnityEngine;
using CleanArchitecture.Application.Navigation;
using CleanArchitecture.Infrastructure.Navigation;

namespace CleanArchitecture.Presentation.Navigation
{
    /// <summary>
    /// MonoBehaviour opcional para exponer navegación limpia sin tocar SceneLoader legacy.
    /// </summary>
    public class NavigationAdapter : MonoBehaviour
    {
        private NavigationService service;

        private void Awake()
        {
            var repo = new UnitySceneRepository();
            service = new NavigationService(repo);
        }

        public void LoadScene(string sceneName)
        {
            service?.LoadScene(sceneName);
        }

        public void ReloadCurrent()
        {
            service?.Reload();
        }
    }
}
