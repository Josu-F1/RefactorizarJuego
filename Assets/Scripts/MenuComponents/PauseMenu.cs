using UnityEngine;
using MenuSystem;

/// <summary>
/// ✅ Clean Architecture - Pause Menu usando MenuSystemComposer
/// </summary>
public class PauseMenu : BaseMenu
{
    [SerializeField] private GameObject pauseLayer;
    
    protected override void Awake()
    {
        base.Awake();
        menuName = "PauseMenu";
        pauseGameWhenVisible = true; // ✅ Auto-pause when shown
    }
    
    protected override void Start()
    {
        base.Start(); // ✅ Register with MenuSystemComposer
        Resume();
        Debug.Log("[PauseMenu] ✅ Using MenuSystemComposer (Clean Architecture)");
    }
    
    public void HandlePause()
    {
        if (IsVisible)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
    
    private void Pause()
    {
        if (pauseLayer != null) pauseLayer.SetActive(true);
        menuSystem?.PauseGame();
    }
    
    private void Resume()
    {
        if (pauseLayer != null) pauseLayer.SetActive(false);
        menuSystem?.ResumeGame();
    }
}