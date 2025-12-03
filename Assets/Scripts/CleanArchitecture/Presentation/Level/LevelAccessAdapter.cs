using UnityEngine;
using CleanArchitecture.Application.Level;
using CleanArchitecture.Infrastructure.Level;
using CleanArchitecture.Domain.Level;
using CleanArchitecture.Presentation.Auth;

namespace CleanArchitecture.Presentation.Level
{
    /// <summary>
    /// MonoBehaviour opcional para validar acceso a niveles usando datos legacy.
    /// Puede trabajar con AuthServiceAdapter o con DataManagerComposer directamente.
    /// </summary>
    public class LevelAccessAdapter : MonoBehaviour
    {
        [SerializeField] private AuthServiceAdapter authAdapter;
        [SerializeField] private string overrideUsername;

        private LevelAccessService service;

        private void Awake()
        {
            if (authAdapter == null)
            {
                authAdapter = FindObjectOfType<AuthServiceAdapter>();
            }

            var reader = new DataManagerLevelProgressReader();
            service = new LevelAccessService(reader);
        }

        /// <summary>
        /// Retorna el resultado de acceso para el nivel solicitado usando el usuario actual o el override.
        /// </summary>
        public LevelAccessResult CanAccess(int requestedLevel)
        {
            string user = !string.IsNullOrWhiteSpace(overrideUsername)
                ? overrideUsername
                : (authAdapter != null ? authAdapter.CurrentUser() : global::DataManagerComposer.CurrentUsername);

            return service.CanAccess(user, requestedLevel);
        }
    }
}
