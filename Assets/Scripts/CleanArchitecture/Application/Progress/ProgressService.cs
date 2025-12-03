using System;
using ProgressDomain = CleanArchitecture.Domain.Progress;

namespace CleanArchitecture.Application.Progress
{
    /// <summary>
    /// Caso de uso: gestiona nivel alcanzado por usuario.
    /// </summary>
    public class ProgressService
    {
        private readonly ProgressDomain.IProgressRepository repository;

        public ProgressService(ProgressDomain.IProgressRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public ProgressDomain.UserProgressRecord GetProgress(string username)
        {
            return repository.Load(username);
        }

        public void SaveLevel(string username, int level)
        {
            if (string.IsNullOrWhiteSpace(username) || level < 0) return;
            var record = new ProgressDomain.UserProgressRecord(username, level);
            repository.Save(record);
        }

        public void CompleteLevelIfHigher(string username, int completedLevel)
        {
            if (string.IsNullOrWhiteSpace(username) || completedLevel < 0) return;

            var current = repository.Load(username);
            if (completedLevel > current.Level)
            {
                repository.Save(new ProgressDomain.UserProgressRecord(username, completedLevel));
            }
        }
    }
}
