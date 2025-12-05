namespace CleanArchitecture.Domain.Progress
{
    /// <summary>
    /// Estado mínimo de progreso por usuario (nivel alcanzado).
    /// </summary>
    public readonly struct UserProgressRecord
    {
        public readonly string Username;
        public readonly int Level;

        public UserProgressRecord(string username, int level)
        {
            Username = username;
            Level = level;
        }
    }
}
