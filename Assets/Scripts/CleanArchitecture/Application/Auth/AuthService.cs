using System;
using CleanArchitecture.Domain.Auth;

namespace CleanArchitecture.Application.Auth
{
    /// <summary>
    /// Caso de uso para login/registro/cierre de sesión.
    /// </summary>
    public class AuthService
    {
        private readonly IUserAuthRepository repository;

        public event Action<string> OnLoggedIn;
        public event Action OnLoggedOut;

        public AuthService(IUserAuthRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public AuthResult Register(string username)
        {
            var creds = new CleanArchitecture.Domain.Auth.UserCredentials(username);
            var result = repository.Register(creds);
            if (result.Success)
            {
                OnLoggedIn?.Invoke(username);
            }
            return result;
        }

        public AuthResult Login(string username)
        {
            var creds = new CleanArchitecture.Domain.Auth.UserCredentials(username);
            var result = repository.Login(creds);
            if (result.Success)
            {
                OnLoggedIn?.Invoke(username);
            }
            return result;
        }

        public void Logout()
        {
            repository.Logout();
            OnLoggedOut?.Invoke();
        }

        public bool HasActiveSession() => repository.HasActiveSession();
        public string CurrentUser() => repository.CurrentUser();
    }
}
