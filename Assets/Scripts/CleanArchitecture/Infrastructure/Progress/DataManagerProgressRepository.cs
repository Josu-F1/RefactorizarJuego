using System;
using ProgressDomain = CleanArchitecture.Domain.Progress;

/// <summary>
/// Adaptador que usa DataManagerComposer para leer/escribir progreso.
/// </summary>
namespace CleanArchitecture.Infrastructure.Progress
{
    public class DataManagerProgressRepository : ProgressDomain.IProgressRepository
    {
        public ProgressDomain.UserProgressRecord Load(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return new ProgressDomain.UserProgressRecord(string.Empty, 0);
            }
            int level = global::DataManagerComposer.GetPlayerLevel(username);
            return new ProgressDomain.UserProgressRecord(username, level);
        }

        public void Save(ProgressDomain.UserProgressRecord record)
        {
            if (string.IsNullOrWhiteSpace(record.Username)) return;
            global::DataManagerComposer.SavePlayerLevel(record.Username, record.Level);
        }
    }
}
