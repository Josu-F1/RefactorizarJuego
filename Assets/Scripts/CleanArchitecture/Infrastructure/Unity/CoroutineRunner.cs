using System;
using System.Collections;
using UnityEngine;

namespace CleanArchitecture.Infrastructure
{
    /// <summary>
    /// Helper para ejecutar Coroutines desde clases no-MonoBehaviour
    /// </summary>
    public class CoroutineRunner : MonoBehaviour
    {
        private static CoroutineRunner _instance;
        public static CoroutineRunner Instance
        {
            get
            {
                if (_instance == null)
                {
                    var go = new GameObject("[CoroutineRunner]");
                    _instance = go.AddComponent<CoroutineRunner>();
                    DontDestroyOnLoad(go);
                }
                return _instance;
            }
        }

        /// <summary>
        /// Ejecuta una acción después de un delay
        /// </summary>
        public void DelayedAction(float delay, Action action)
        {
            StartCoroutine(DelayedActionCoroutine(delay, action));
        }

        private IEnumerator DelayedActionCoroutine(float delay, Action action)
        {
            yield return new WaitForSeconds(delay);
            action?.Invoke();
        }

        private void OnDestroy()
        {
            if (_instance == this)
            {
                _instance = null;
            }
        }
    }
}
