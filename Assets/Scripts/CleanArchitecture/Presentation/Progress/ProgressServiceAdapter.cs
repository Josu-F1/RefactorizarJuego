using UnityEngine;
using CleanArchitecture.Application.Progress;
using CleanArchitecture.Infrastructure.Progress;
using ProgressDomain = CleanArchitecture.Domain.Progress;

namespace CleanArchitecture.Presentation.Progress
{
    /// <summary>
    /// MonoBehaviour opcional para exponer ProgressService.
    /// </summary>
    public class ProgressServiceAdapter : MonoBehaviour
    {
        private ProgressService service;

        private void Awake()
        {
            var repo = new DataManagerProgressRepository();
            service = new ProgressService(repo);
        }

        public ProgressDomain.UserProgressRecord GetProgress(string username) => service.GetProgress(username);
        public void SaveLevel(string username, int level) => service.SaveLevel(username, level);
        public void CompleteLevelIfHigher(string username, int completedLevel) => service.CompleteLevelIfHigher(username, completedLevel);
    }
}
