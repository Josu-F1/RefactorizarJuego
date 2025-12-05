using System;
using CleanArchitecture.Domain.Navigation;

namespace CleanArchitecture.Application.Navigation
{
    /// <summary>
    /// Caso de uso: orquesta navegación entre escenas.
    /// </summary>
    public class NavigationService
    {
        private readonly INavRepository repository;

        public NavigationService(INavRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public void LoadScene(string sceneName)
        {
            var scene = new SceneId(sceneName);
            if (!scene.IsValid) return;
            repository.Load(scene);
        }

        public void Reload()
        {
            repository.ReloadCurrent();
        }
    }
}
