using UnityEngine;
using UnityEngine.UI;
using CleanArchitecture.Presentation.Score;

namespace CleanArchitecture.Presentation.UI
{
    /// <summary>
    /// Presenter opcional para conectar ScoreServiceAdapter con una barra de UI sin tocar ScoreBar legacy.
    /// Añádelo a un Image/Slider en una escena de prueba.
    /// </summary>
    public class ScoreUIPresenter : MonoBehaviour
    {
        [SerializeField] private ScoreServiceAdapter scoreAdapter;
        [SerializeField] private Image fillImage;
        [SerializeField] private Slider slider;

        private void Awake()
        {
            if (scoreAdapter == null)
            {
                scoreAdapter = FindObjectOfType<ScoreServiceAdapter>();
            }

            BindAdapter();
            Render(scoreAdapter?.Snapshot ?? default);
        }

        private void OnDestroy()
        {
            if (scoreAdapter != null)
            {
                scoreAdapter.OnScoreChanged -= Render;
            }
        }

        private void BindAdapter()
        {
            if (scoreAdapter == null) return;
            scoreAdapter.OnScoreChanged += Render;
        }

        private void Render(CleanArchitecture.Domain.Score.ScoreSnapshot snapshot)
        {
            float progress = snapshot.Required > 0 ? snapshot.Progress : 0f;
            if (fillImage != null)
            {
                fillImage.fillAmount = progress;
            }
            if (slider != null)
            {
                slider.value = progress;
            }
        }
    }
}
