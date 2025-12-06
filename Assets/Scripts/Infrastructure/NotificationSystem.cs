using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Notifications
{
    /// <summary>
    /// ✅ Clean Architecture - Notification System
    /// Patrón: Observer + Command
    /// Responsabilidad: Gestionar notificaciones UI (toasts, mensajes)
    /// </summary>
    public class NotificationSystem : MonoBehaviourSingleton<NotificationSystem>
    {
        [Header("Configuration")]
        [SerializeField] private NotificationConfig defaultConfig;
        
        private Queue<Notification> notificationQueue = new Queue<Notification>();
        private Notification? currentNotification;
        private bool isShowingNotification = false;
        
        #region Show Notifications
        
        public void ShowInfo(string message, float duration = 3f)
        {
            Show(new Notification
            {
                Message = message,
                Type = NotificationType.Info,
                Duration = duration,
                Priority = NotificationPriority.Normal
            });
        }
        
        public void ShowSuccess(string message, float duration = 3f)
        {
            Show(new Notification
            {
                Message = message,
                Type = NotificationType.Success,
                Duration = duration,
                Priority = NotificationPriority.Normal
            });
        }
        
        public void ShowWarning(string message, float duration = 3f)
        {
            Show(new Notification
            {
                Message = message,
                Type = NotificationType.Warning,
                Duration = duration,
                Priority = NotificationPriority.High
            });
        }
        
        public void ShowError(string message, float duration = 5f)
        {
            Show(new Notification
            {
                Message = message,
                Type = NotificationType.Error,
                Duration = duration,
                Priority = NotificationPriority.Critical
            });
        }
        
        private void Show(Notification notification)
        {
            if (notification.Priority == NotificationPriority.Critical)
            {
                // Interrumpir notificación actual si es crítica
                if (isShowingNotification)
                {
                    StopAllCoroutines();
                    isShowingNotification = false;
                }
                StartCoroutine(ShowNotificationCoroutine(notification));
            }
            else
            {
                // Agregar a cola
                notificationQueue.Enqueue(notification);
                if (!isShowingNotification)
                {
                    StartCoroutine(ProcessQueue());
                }
            }
        }
        
        #endregion
        
        #region Coroutines
        
        private IEnumerator ProcessQueue()
        {
            while (notificationQueue.Count > 0)
            {
                var notification = notificationQueue.Dequeue();
                yield return StartCoroutine(ShowNotificationCoroutine(notification));
            }
        }
        
        private IEnumerator ShowNotificationCoroutine(Notification notification)
        {
            isShowingNotification = true;
            currentNotification = notification;
            
            // Notificar a listeners (UI)
            OnNotificationShown?.Invoke(notification);
            
            Debug.Log($"[Notification] {notification.Type}: {notification.Message}");
            
            yield return new WaitForSeconds(notification.Duration);
            
            OnNotificationHidden?.Invoke(notification);
            isShowingNotification = false;
            currentNotification = null;
        }
        
        #endregion
        
        #region Events
        
        public event Action<Notification> OnNotificationShown;
        public event Action<Notification> OnNotificationHidden;
        
        #endregion
        
        #region Clear
        
        public void Clear()
        {
            StopAllCoroutines();
            notificationQueue.Clear();
            isShowingNotification = false;
            currentNotification = null;
        }
        
        #endregion
    }
    
    #region Data Structures
    
    /// <summary>
    /// Estructura de notificación
    /// </summary>
    [System.Serializable]
    public struct Notification
    {
        public string Message;
        public NotificationType Type;
        public float Duration;
        public NotificationPriority Priority;
    }
    
    public enum NotificationType
    {
        Info,
        Success,
        Warning,
        Error
    }
    
    public enum NotificationPriority
    {
        Low,
        Normal,
        High,
        Critical
    }
    
    /// <summary>
    /// Configuración de notificaciones
    /// </summary>
    [CreateAssetMenu(fileName = "NotificationConfig", menuName = "Infrastructure/NotificationConfig")]
    public class NotificationConfig : ScriptableObject
    {
        [Header("Durations")]
        public float infoDuration = 3f;
        public float successDuration = 3f;
        public float warningDuration = 4f;
        public float errorDuration = 5f;
        
        [Header("Colors")]
        public Color infoColor = Color.white;
        public Color successColor = Color.green;
        public Color warningColor = Color.yellow;
        public Color errorColor = Color.red;
    }
    
    #endregion
}
