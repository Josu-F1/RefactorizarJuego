namespace CleanArchitecture.Domain.Level
{
    /// <summary>
    /// Resultado de chequeo de acceso a nivel.
    /// </summary>
    public readonly struct LevelAccessResult
    {
        public readonly bool CanAccess;
        public readonly int HighestCompletedLevel;
        public readonly string Message;

        public LevelAccessResult(bool canAccess, int highestCompletedLevel, string message = "")
        {
            CanAccess = canAccess;
            HighestCompletedLevel = highestCompletedLevel;
            Message = message;
        }

        public static LevelAccessResult Allowed(int highest) => new LevelAccessResult(true, highest, "");
        public static LevelAccessResult Denied(int highest, string message) => new LevelAccessResult(false, highest, message);
    }
}
