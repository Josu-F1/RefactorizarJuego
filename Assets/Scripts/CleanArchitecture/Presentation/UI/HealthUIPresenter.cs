using UnityEngine;
using UnityEngine.UI;
using CleanArchitecture.Presentation.Health;

namespace CleanArchitecture.Presentation.UI
{
    /// <summary>
    /// Presenter opcional para conectar HealthServiceAdapter con barras/sliders de UI sin tocar HealthBar legacy.
    /// </summary>
    public class HealthUIPresenter : MonoBehaviour
    {
        [SerializeField] private HealthServiceAdapter healthAdapter;
        [SerializeField] private Image fillImage;
        [SerializeField] private Slider slider;

        private void Awake()
        {
            if (healthAdapter == null)
            {
                healthAdapter = GetComponentInParent<HealthServiceAdapter>() ?? FindObjectOfType<HealthServiceAdapter>();
            }

            BindAdapter();
            Render(healthAdapter?.Snapshot ?? default);
        }

        private void OnDestroy()
        {
            if (healthAdapter != null)
            {
                healthAdapter.OnChanged -= Render;
            }
        }

        private void BindAdapter()
        {
            if (healthAdapter == null) return;
            healthAdapter.OnChanged += Render;
        }

        private void Render(CleanArchitecture.Domain.Health.HealthSnapshot snapshot)
        {
            float pct = snapshot.Percentage;
            if (fillImage != null)
            {
                fillImage.fillAmount = pct;
            }
            if (slider != null)
            {
                slider.value = pct;
            }
        }
    }
}
