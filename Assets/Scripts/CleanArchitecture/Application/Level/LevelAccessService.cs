using System;
using CleanArchitecture.Domain.Level;

namespace CleanArchitecture.Application.Level
{
    /// <summary>
    /// Caso de uso: valida si un usuario puede acceder a un nivel dado.
    /// Regla simple: puede acceder hasta el nivel (highestCompleted + 1).
    /// </summary>
    public class LevelAccessService
    {
        private readonly ILevelProgressReader progressReader;

        public LevelAccessService(ILevelProgressReader progressReader)
        {
            this.progressReader = progressReader ?? throw new ArgumentNullException(nameof(progressReader));
        }

        public LevelAccessResult CanAccess(string username, int requestedLevel)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return LevelAccessResult.Denied(0, "Usuario inválido");
            }

            if (requestedLevel <= 0)
            {
                return LevelAccessResult.Allowed(progressReader.GetCompletedLevel(username));
            }

            int completed = progressReader.GetCompletedLevel(username);
            int maxAllowed = completed + 1;

            if (requestedLevel <= maxAllowed)
            {
                return LevelAccessResult.Allowed(completed);
            }

            return LevelAccessResult.Denied(completed, $"Nivel bloqueado. Completa el nivel {completed + 1} primero.");
        }
    }
}
