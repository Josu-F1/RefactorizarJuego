namespace CleanArchitecture.Domain.Auth
{
    /// <summary>
    /// Valor simple para representar credenciales (usuario únicamente en este proyecto).
    /// </summary>
    public readonly struct UserCredentials
    {
        public readonly string Username;

        public UserCredentials(string username)
        {
            Username = username;
        }

        public bool IsValid => !string.IsNullOrWhiteSpace(Username);
    }
}
