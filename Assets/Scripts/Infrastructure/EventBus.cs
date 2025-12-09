using System;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Events
{
    /// <summary>
    /// ✅ Clean Architecture - Event Bus Global
    /// Patrón: Observer + Mediator
    /// Responsabilidad: Desacoplar componentes mediante eventos globales
    /// </summary>
    public class EventBus : MonoBehaviourSingleton<EventBus>
    {
        private Dictionary<Type, List<Delegate>> eventHandlers = new Dictionary<Type, List<Delegate>>();
        
        #region Subscribe/Unsubscribe
        
        public void Subscribe<TEvent>(Action<TEvent> handler) where TEvent : IGameEvent
        {
            Type eventType = typeof(TEvent);
            
            if (!eventHandlers.ContainsKey(eventType))
            {
                eventHandlers[eventType] = new List<Delegate>();
            }
            
            eventHandlers[eventType].Add(handler);
        }
        
        public void Unsubscribe<TEvent>(Action<TEvent> handler) where TEvent : IGameEvent
        {
            Type eventType = typeof(TEvent);
            
            if (eventHandlers.ContainsKey(eventType))
            {
                eventHandlers[eventType].Remove(handler);
            }
        }
        
        #endregion
        
        #region Publish
        
        public void Publish<TEvent>(TEvent gameEvent) where TEvent : IGameEvent
        {
            Type eventType = typeof(TEvent);
            
            if (eventHandlers.ContainsKey(eventType))
            {
                var handlers = eventHandlers[eventType];
                foreach (var handler in handlers)
                {
                    ((Action<TEvent>)handler).Invoke(gameEvent);
                }
            }
        }
        
        #endregion
        
        #region Clear
        
        public void Clear()
        {
            eventHandlers.Clear();
        }
        
        public void Clear<TEvent>() where TEvent : IGameEvent
        {
            Type eventType = typeof(TEvent);
            if (eventHandlers.ContainsKey(eventType))
            {
                eventHandlers[eventType].Clear();
            }
        }
        
        #endregion
    }
    
    #region Event Interfaces
    
    /// <summary>
    /// Marker interface para todos los eventos del juego
    /// </summary>
    public interface IGameEvent { }
    
    #endregion
    
    #region Game Events (Domain)
    
    /// <summary>
    /// Evento: Personaje murió
    /// </summary>
    public struct CharacterDiedEvent : IGameEvent
    {
        public CharacterType CharacterType { get; }
        public GameObject GameObject { get; }
        public int Score { get; }
        
        public CharacterDiedEvent(CharacterType type, GameObject gameObject, int score)
        {
            CharacterType = type;
            GameObject = gameObject;
            Score = score;
        }
    }
    
    /// <summary>
    /// Evento: Personaje recibió daño
    /// </summary>
    public struct CharacterDamagedEvent : IGameEvent
    {
        public CharacterType CharacterType { get; }
        public GameObject GameObject { get; }
        public float DamageAmount { get; }
        public float CurrentHealth { get; }
        
        public CharacterDamagedEvent(CharacterType type, GameObject gameObject, float damage, float currentHealth)
        {
            CharacterType = type;
            GameObject = gameObject;
            DamageAmount = damage;
            CurrentHealth = currentHealth;
        }
    }
    
    /// <summary>
    /// Evento: Personaje sanado
    /// </summary>
    public struct CharacterHealedEvent : IGameEvent
    {
        public CharacterType CharacterType { get; }
        public GameObject GameObject { get; }
        public float HealAmount { get; }
        public float CurrentHealth { get; }
        
        public CharacterHealedEvent(CharacterType type, GameObject gameObject, float heal, float currentHealth)
        {
            CharacterType = type;
            GameObject = gameObject;
            HealAmount = heal;
            CurrentHealth = currentHealth;
        }
    }
    
    /// <summary>
    /// Evento: Pickup recogido
    /// </summary>
    public struct PickupCollectedEvent : IGameEvent
    {
        public string PickupType { get; }
        public GameObject PickupObject { get; }
        public GameObject Collector { get; }
        
        public PickupCollectedEvent(string type, GameObject pickup, GameObject collector)
        {
            PickupType = type;
            PickupObject = pickup;
            Collector = collector;
        }
    }
    
    /// <summary>
    /// Evento: Habilidad activada
    /// </summary>
    public struct AbilityActivatedEvent : IGameEvent
    {
        public string AbilityName { get; }
        public GameObject Caster { get; }
        
        public AbilityActivatedEvent(string abilityName, GameObject caster)
        {
            AbilityName = abilityName;
            Caster = caster;
        }
    }
    
    /// <summary>
    /// Evento: Nivel completado
    /// </summary>
    public struct LevelCompletedEvent : IGameEvent
    {
        public int LevelNumber { get; }
        public int Score { get; }
        public float CompletionTime { get; }
        
        public LevelCompletedEvent(int level, int score, float time)
        {
            LevelNumber = level;
            Score = score;
            CompletionTime = time;
        }
    }
    
    /// <summary>
    /// Evento: Game Over
    /// </summary>
    public struct GameOverEvent : IGameEvent
    {
        public int FinalScore { get; }
        public string Reason { get; }
        
        public GameOverEvent(int score, string reason)
        {
            FinalScore = score;
            Reason = reason;
        }
    }
    
    /// <summary>
    /// Evento: Juego pausado/reanudado
    /// </summary>
    public struct GamePausedEvent : IGameEvent
    {
        public bool IsPaused { get; }
        
        public GamePausedEvent(bool paused)
        {
            IsPaused = paused;
        }
    }
    
    #endregion
}
