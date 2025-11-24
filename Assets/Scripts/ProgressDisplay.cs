using UnityEngine;
using UnityEngine.UI;

public class ProgressDisplay : MonoBehaviour
{
    public Text userNameText;
    public Text levelText;
    public Text pointsText;

    private UserProgress currentProgress;

    void Start()
    {
        string userName = PlayerPrefs.GetString("CurrentUser", "");
        if (!string.IsNullOrEmpty(userName))
        {
            LoadUser(userName);
        }
    }

    // Permite cargar el progreso de un usuario específico
    public void LoadUser(string userName)
    {
        currentProgress = UserProgressManager.LoadProgress(userName);
        UpdateUI();
    }

    public void SaveProgress()
    {
        if (currentProgress != null)
        {
            UserProgressManager.SaveProgress(currentProgress);
        }
    }

    public void AddPoints(int points)
    {
        if (currentProgress != null)
        {
            currentProgress.points += points;
            UpdateUI();
            SaveProgress();
        }
    }

    public void NextLevel()
    {
        if (currentProgress != null)
        {
            currentProgress.level++;
            UpdateUI();
            SaveProgress();
        }
    }

    private void UpdateUI()
    {
        userNameText.text = "Usuario: " + currentProgress.userName;
        levelText.text = "Nivel: " + currentProgress.level;
        pointsText.text = "Puntos: " + currentProgress.points;
    }
}



