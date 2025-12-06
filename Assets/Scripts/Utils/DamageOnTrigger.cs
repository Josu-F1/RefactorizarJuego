using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnTrigger : MonoBehaviour
{
    [SerializeField] private float damage = 100;
    private CharacterType characterType;
    private void Awake() {
        characterType = GetComponentInParent<ICharacter>().CharacterType;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Usar CharacterSystemComposer
        var characterSystem = CharacterSystemComposer.Instance;
        if (characterSystem != null)
        {
            var controller = characterSystem.GetController(other.gameObject);
            if (controller != null && controller.CharacterType != characterType)
            {
                controller.NotifyEvent(CharacterEvent.HealthDepleted, damage);
            }
            return;
        }
    }    
}