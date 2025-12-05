using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// Maneja los estados del juego (jugando, victoria, derrota)
/// Principio: Single Responsibility Principle (SRP) - Solo estados del juego
/// </summary>
public class GameStateManager : MonoBehaviour, IGameStateManager
{
    [SerializeField] private float endGameDelay = 2f;
    
    private bool isPlaying = true;
    
    public bool IsPlaying => isPlaying;
    
    public event Action OnVictory;
    public event Action OnDefeat;  
    public event Action OnGameStateChanged;
    
    private void Start()
    {
        ResetGameState();
    }
    
    public void TriggerVictory()
    {
        if (!isPlaying) return;
        
        Debug.Log("Victory!");
        isPlaying = false;
        OnGameStateChanged?.Invoke();
        StartCoroutine(VictoryCoroutine());
    }
    
    public void TriggerDefeat()
    {
        if (!isPlaying) return;
        
        Debug.Log("Defeat!");
        isPlaying = false;
        OnGameStateChanged?.Invoke();
        StartCoroutine(DefeatCoroutine());
    }
    
    public void ResetGameState()
    {
        isPlaying = true;
        Time.timeScale = 1f; // Asegurar tiempo normal
        OnGameStateChanged?.Invoke();
    }
    
    private IEnumerator VictoryCoroutine()
    {
        yield return new WaitForSeconds(endGameDelay);
        OnVictory?.Invoke();
        Time.timeScale = 0;
    }
    
    private IEnumerator DefeatCoroutine()
    {
        yield return new WaitForSeconds(endGameDelay);
        OnDefeat?.Invoke();
        Time.timeScale = 0;
    }
}