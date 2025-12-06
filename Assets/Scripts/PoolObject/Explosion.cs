#pragma warning disable CS0618 // El tipo o miembro está obsoleto
using UnityEngine;

public class Explosion : PoolObject
{
    public float Damage { get; set; }
    public CharacterType CharacterType { get; set; }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Aplicar daño solo a personajes de tipo diferente (evitar friendly fire)
        var health = other.GetComponent<global::Health>();
        if (health != null)
        {
            ICharacter hitCharacter = other.GetComponent<ICharacter>();
            if (hitCharacter != null && hitCharacter.CharacterType != CharacterType)
            {
                health.TakeDamage(Damage);
                
                // Notificar evento si está registrado en CharacterSystemComposer
                var characterSystem = CharacterSystemComposer.Instance;
                var controller = characterSystem?.GetController(other.gameObject);
                controller?.NotifyEvent(CharacterEvent.HealthDepleted, Damage);
            }
        }
        DestructibleTilemap destructibleTilemap = other.GetComponent<DestructibleTilemap>();
        if (destructibleTilemap != null)
        {
            destructibleTilemap.DestroyTile(transform.position);
            return;
        }
        Bomb bomb = other.GetComponent<Bomb>();
        if (bomb != null && bomb.CharacterType == CharacterType && bomb.Destination == null) bomb.Explode();
    }
}

