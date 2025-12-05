using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSaver : MonoBehaviour
{
    [SerializeField] private string id = "";
    [SerializeField] private bool useInitialPosition = true; // Nueva opción para usar posición inicial
    [SerializeField] private Vector3 initialPosition = Vector3.zero; // Posición inicial personalizable
    [SerializeField] private bool resetPositionOnStart = true; // Reiniciar posición al inicio
    
    private string xKey;
    private string yKey;
    private void Start()
    {
        xKey = id+"X";
        yKey =id+"Y";
        
        // Si queremos usar la posición inicial o reiniciar, no cargar la posición guardada
        if (useInitialPosition || resetPositionOnStart)
        {
            // Si hay una posición inicial definida, usarla; sino, usar la posición actual del transform
            Vector3 targetPosition = initialPosition != Vector3.zero ? initialPosition : transform.position;
            transform.position = targetPosition;
            
            // Si resetPositionOnStart está activo, limpiar los PlayerPrefs guardados
            if (resetPositionOnStart)
            {
                PlayerPrefs.DeleteKey(xKey);
                PlayerPrefs.DeleteKey(yKey);
            }
        }
        else
        {
            // Comportamiento original: cargar posición guardada
            float x = PlayerPrefs.GetFloat(xKey, transform.position.x);
            float y = PlayerPrefs.GetFloat(yKey, transform.position.y);
            transform.position = new Vector3(x, y, 0);
        }
    }
    private void OnDestroy()
    {
        PlayerPrefs.SetFloat(xKey, transform.position.x);
        PlayerPrefs.SetFloat(yKey, transform.position.y);
    }
}
