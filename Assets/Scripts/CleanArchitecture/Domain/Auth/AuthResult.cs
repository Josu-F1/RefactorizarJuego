namespace CleanArchitecture.Domain.Auth
{
    public readonly struct AuthResult
    {
        public readonly bool Success;
        public readonly string Message;

        public AuthResult(bool success, string message = "")
        {
            Success = success;
            Message = message;
        }

        public static AuthResult Ok => new AuthResult(true);
        public static AuthResult Fail(string message) => new AuthResult(false, message);
    }
}
