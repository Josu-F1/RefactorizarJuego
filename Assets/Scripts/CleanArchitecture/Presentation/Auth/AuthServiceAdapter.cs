using UnityEngine;
using CleanArchitecture.Application.Auth;
using CleanArchitecture.Infrastructure.Auth;

namespace CleanArchitecture.Presentation.Auth
{
    /// <summary>
    /// MonoBehaviour opcional para exponer AuthService sin tocar UI de login legacy.
    /// </summary>
    public class AuthServiceAdapter : MonoBehaviour
    {
        private AuthService service;

        public AuthService Service => service;

        private void Awake()
        {
            var repo = new DataManagerAuthRepository();
            service = new AuthService(repo);
        }

        public bool HasActiveSession() => service?.HasActiveSession() ?? false;
        public string CurrentUser() => service?.CurrentUser();

        public Domain.Auth.AuthResult Register(string username)
        {
            return service?.Register(username) ?? Domain.Auth.AuthResult.Fail("Service not initialized");
        }

        public Domain.Auth.AuthResult Login(string username)
        {
            return service?.Login(username) ?? Domain.Auth.AuthResult.Fail("Service not initialized");
        }

        public void Logout()
        {
            service?.Logout();
        }
    }
}
