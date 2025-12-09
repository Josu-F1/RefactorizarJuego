using UnityEngine;
using UnityEngine.UI;

public class EndGameDisplay : MonoBehaviour
{
    [SerializeField] private GameObject victoryDisplay;
    [SerializeField] private GameObject defeatDisplay;
    [Header("Victory Buttons")]
    [SerializeField] private Button replayButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private string menuSceneName = "MainMenu";
    private GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.Instance;
        gameManager.OnVictory += DisplayVictory;
        gameManager.OnDefeat += DisplayDefeat;
        ConfigureVictoryButtons();
    }
    private void DisplayDefeat()
    {
        defeatDisplay.SetActive(true);
    }
    private void DisplayVictory()
    {
        victoryDisplay.SetActive(true);
    }
    private void ConfigureVictoryButtons()
    {
        if (replayButton != null)
        {
            replayButton.onClick.AddListener(RestartLevel);
        }
        else
        {
            Debug.LogWarning("[EndGameDisplay] Replay button reference is missing");
        }

        if (nextButton != null)
        {
            nextButton.onClick.AddListener(GoToMenu);
        }
        else
        {
            Debug.LogWarning("[EndGameDisplay] Next button reference is missing");
        }
    }

    private void RestartLevel()
    {
        SceneLoader.LoadCurrentScene();
    }

    private void GoToMenu()
    {
        if (string.IsNullOrEmpty(menuSceneName))
        {
            Debug.LogWarning("[EndGameDisplay] Menu scene name not configured");
            return;
        }

        SceneLoader.Load(menuSceneName);
    }
    private void OnDestroy()
    {
        gameManager.OnVictory -= DisplayVictory;
        gameManager.OnDefeat -= DisplayDefeat;
    }
}
