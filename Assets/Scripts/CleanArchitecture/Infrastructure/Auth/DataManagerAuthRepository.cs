using System;
using CleanArchitecture.Domain.Auth;

/// <summary>
/// Adaptador que reutiliza DataManagerComposer/UserRepository/SessionManager legacy para autenticación simple.
/// </summary>
namespace CleanArchitecture.Infrastructure.Auth
{
    public class DataManagerAuthRepository : IUserAuthRepository
    {
        public AuthResult Register(CleanArchitecture.Domain.Auth.UserCredentials credentials)
        {
            if (!credentials.IsValid)
            {
                return AuthResult.Fail("Username inválido");
            }

            if (global::DataManagerComposer.UsernameExists(credentials.Username))
            {
                return AuthResult.Fail("Usuario ya existe");
            }

            global::DataManagerComposer.SaveUsername(credentials.Username);
            return AuthResult.Ok;
        }

        public AuthResult Login(CleanArchitecture.Domain.Auth.UserCredentials credentials)
        {
            if (!credentials.IsValid)
            {
                return AuthResult.Fail("Username inválido");
            }

            // En este proyecto el login se valida por existencia.
            if (!global::DataManagerComposer.UsernameExists(credentials.Username))
            {
                return AuthResult.Fail("Usuario no existe");
            }

            global::DataManagerComposer.StartSession(credentials.Username);
            return AuthResult.Ok;
        }

        public void Logout()
        {
            global::DataManagerComposer.EndSession();
        }

        public bool HasActiveSession()
        {
            return global::DataManagerComposer.HasActiveSession();
        }

        public string CurrentUser()
        {
            return global::DataManagerComposer.CurrentUsername;
        }
    }
}
