namespace CleanArchitecture.Domain.Auth
{
    /// <summary>
    /// Contrato para autenticación/gestión de sesión.
    /// Implementaciones viven en infraestructura.
    /// </summary>
    public interface IUserAuthRepository
    {
        AuthResult Register(UserCredentials credentials);
        AuthResult Login(UserCredentials credentials);
        void Logout();
        bool HasActiveSession();
        string CurrentUser();
    }
}
