using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    [SerializeField] private bool shouldDieAfterCollision = true;
    [SerializeField] private float damage;
    private CharacterType characterType;
    private void Awake()
    {
        characterType = GetComponentInParent<ICharacter>().CharacterType;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        // Usar CharacterSystemComposer
        var characterSystem = CharacterSystemComposer.Instance;
        if (characterSystem == null) return;
        
        var controller = characterSystem.GetController(other.gameObject);
        if (controller == null || controller.CharacterType == characterType) return;
        
        controller.NotifyEvent(CharacterEvent.HealthDepleted, damage);
        
        if (shouldDieAfterCollision)
        {
            var selfController = characterSystem.GetController(gameObject);
            selfController?.NotifyEvent(CharacterEvent.Death);
        }
    }
}
