using System;
using UnityEngine;
using Infrastructure.Events;

namespace Presentation.MVP
{
    /// <summary>
    /// ✅ Clean Architecture - MVP Pattern for UI
    /// Patrón: Model-View-Presenter
    /// Responsabilidad: Desacoplar lógica de UI de la presentación
    /// </summary>
    /// 
    #region Base Interfaces
    
    public interface IView
    {
        void Initialize();
        void Show();
        void Hide();
    }
    
    public interface IPresenter
    {
        void OnViewReady();
        void OnViewDestroyed();
    }
    
    #endregion
    
    #region Health Bar MVP
    
    /// <summary>
    /// Vista de barra de salud
    /// </summary>
    public interface IHealthBarView : IView
    {
        void UpdateHealth(float percentage);
        void SetMaxHealth(float maxHealth);
    }
    
    /// <summary>
    /// Presenter de barra de salud
    /// </summary>
    public class HealthBarPresenter : IPresenter
    {
        private readonly IHealthBarView view;
        private readonly GameObject targetCharacter;
        
        public HealthBarPresenter(IHealthBarView view, GameObject target)
        {
            this.view = view;
            this.targetCharacter = target;
        }
        
        public void OnViewReady()
        {
            // Suscribirse a eventos de daño/curación
            EventBus.Instance.Subscribe<CharacterDamagedEvent>(OnCharacterDamaged);
            EventBus.Instance.Subscribe<CharacterHealedEvent>(OnCharacterHealed);
        }
        
        public void OnViewDestroyed()
        {
            EventBus.Instance.Unsubscribe<CharacterDamagedEvent>(OnCharacterDamaged);
            EventBus.Instance.Unsubscribe<CharacterHealedEvent>(OnCharacterHealed);
        }
        
        private void OnCharacterDamaged(CharacterDamagedEvent evt)
        {
            if (evt.GameObject == targetCharacter)
            {
                // Calcular porcentaje (asumiendo maxHealth conocido)
                float percentage = evt.CurrentHealth / 100f; // TODO: obtener maxHealth real
                view.UpdateHealth(percentage);
            }
        }
        
        private void OnCharacterHealed(CharacterHealedEvent evt)
        {
            if (evt.GameObject == targetCharacter)
            {
                float percentage = evt.CurrentHealth / 100f;
                view.UpdateHealth(percentage);
            }
        }
    }
    
    #endregion
    
    #region Score Display MVP
    
    /// <summary>
    /// Vista de score
    /// </summary>
    public interface IScoreView : IView
    {
        void UpdateScore(int score);
        void PlayScoreAnimation();
    }
    
    /// <summary>
    /// Presenter de score
    /// </summary>
    public class ScorePresenter : IPresenter
    {
        private readonly IScoreView view;
        private int currentScore = 0;
        
        public ScorePresenter(IScoreView view)
        {
            this.view = view;
        }
        
        public void OnViewReady()
        {
            EventBus.Instance.Subscribe<CharacterDiedEvent>(OnCharacterDied);
            view.UpdateScore(currentScore);
        }
        
        public void OnViewDestroyed()
        {
            EventBus.Instance.Unsubscribe<CharacterDiedEvent>(OnCharacterDied);
        }
        
        private void OnCharacterDied(CharacterDiedEvent evt)
        {
            if (evt.CharacterType == CharacterType.Enemy)
            {
                currentScore += evt.Score;
                view.UpdateScore(currentScore);
                view.PlayScoreAnimation();
            }
        }
    }
    
    #endregion
    
    #region Level Progress MVP
    
    /// <summary>
    /// Vista de progreso de nivel
    /// </summary>
    public interface ILevelProgressView : IView
    {
        void UpdateProgress(float percentage);
        void SetTargetEnemies(int total);
        void ShowLevelComplete();
    }
    
    /// <summary>
    /// Presenter de progreso de nivel
    /// </summary>
    public class LevelProgressPresenter : IPresenter
    {
        private readonly ILevelProgressView view;
        private int totalEnemies;
        private int enemiesKilled;
        
        public LevelProgressPresenter(ILevelProgressView view, int totalEnemies)
        {
            this.view = view;
            this.totalEnemies = totalEnemies;
        }
        
        public void OnViewReady()
        {
            EventBus.Instance.Subscribe<CharacterDiedEvent>(OnCharacterDied);
            EventBus.Instance.Subscribe<LevelCompletedEvent>(OnLevelCompleted);
            
            view.SetTargetEnemies(totalEnemies);
            UpdateProgress();
        }
        
        public void OnViewDestroyed()
        {
            EventBus.Instance.Unsubscribe<CharacterDiedEvent>(OnCharacterDied);
            EventBus.Instance.Unsubscribe<LevelCompletedEvent>(OnLevelCompleted);
        }
        
        private void OnCharacterDied(CharacterDiedEvent evt)
        {
            if (evt.CharacterType == CharacterType.Enemy)
            {
                enemiesKilled++;
                UpdateProgress();
                
                if (enemiesKilled >= totalEnemies)
                {
                    EventBus.Instance.Publish(new LevelCompletedEvent(1, 0, 0f));
                }
            }
        }
        
        private void OnLevelCompleted(LevelCompletedEvent evt)
        {
            view.ShowLevelComplete();
        }
        
        private void UpdateProgress()
        {
            float percentage = (float)enemiesKilled / totalEnemies;
            view.UpdateProgress(percentage);
        }
    }
    
    #endregion
    
    #region Game Over MVP
    
    /// <summary>
    /// Vista de Game Over
    /// </summary>
    public interface IGameOverView : IView
    {
        void SetFinalScore(int score);
        void SetReason(string reason);
    }
    
    /// <summary>
    /// Presenter de Game Over
    /// </summary>
    public class GameOverPresenter : IPresenter
    {
        private readonly IGameOverView view;
        
        public GameOverPresenter(IGameOverView view)
        {
            this.view = view;
        }
        
        public void OnViewReady()
        {
            EventBus.Instance.Subscribe<GameOverEvent>(OnGameOver);
        }
        
        public void OnViewDestroyed()
        {
            EventBus.Instance.Unsubscribe<GameOverEvent>(OnGameOver);
        }
        
        private void OnGameOver(GameOverEvent evt)
        {
            view.SetFinalScore(evt.FinalScore);
            view.SetReason(evt.Reason);
            view.Show();
        }
    }
    
    #endregion
    
    #region Pause Menu MVP
    
    /// <summary>
    /// Vista de menú de pausa
    /// </summary>
    public interface IPauseMenuView : IView
    {
        void SetPauseState(bool paused);
    }
    
    /// <summary>
    /// Presenter de menú de pausa
    /// </summary>
    public class PauseMenuPresenter : IPresenter
    {
        private readonly IPauseMenuView view;
        
        public PauseMenuPresenter(IPauseMenuView view)
        {
            this.view = view;
        }
        
        public void OnViewReady()
        {
            EventBus.Instance.Subscribe<GamePausedEvent>(OnGamePaused);
        }
        
        public void OnViewDestroyed()
        {
            EventBus.Instance.Unsubscribe<GamePausedEvent>(OnGamePaused);
        }
        
        private void OnGamePaused(GamePausedEvent evt)
        {
            view.SetPauseState(evt.IsPaused);
            
            if (evt.IsPaused)
                view.Show();
            else
                view.Hide();
        }
    }
    
    #endregion
    
    #region Base View Implementation
    
    /// <summary>
    /// Implementación base de View para MonoBehaviours
    /// </summary>
    public abstract class BaseView : MonoBehaviour, IView
    {
        protected IPresenter presenter;
        
        public virtual void Initialize()
        {
            presenter = CreatePresenter();
            presenter?.OnViewReady();
        }
        
        public virtual void Show()
        {
            gameObject.SetActive(true);
        }
        
        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
        
        protected virtual void OnDestroy()
        {
            presenter?.OnViewDestroyed();
        }
        
        protected abstract IPresenter CreatePresenter();
    }
    
    #endregion
}
