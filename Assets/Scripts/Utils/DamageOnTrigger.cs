#pragma warning disable CS0618 // El tipo o miembro está obsoleto
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
        // Aplicar daño directo usando sistema legacy Health
        Health health = other.GetComponent<Health>();
        if (health != null)
        {
            ICharacter hitCharacter = other.GetComponent<ICharacter>();
            if (hitCharacter.CharacterType != characterType)
            {
                health.TakeDamage(damage);
                
                // Notificar evento si está registrado en CharacterSystemComposer
                var characterSystem = CharacterSystemComposer.Instance;
                var controller = characterSystem?.GetController(other.gameObject);
                controller?.NotifyEvent(CharacterEvent.HealthDepleted, damage);
            }
            return;
        }
    }    
}