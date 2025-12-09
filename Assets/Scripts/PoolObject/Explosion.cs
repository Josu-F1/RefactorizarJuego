using UnityEngine;

public class Explosion : PoolObject
{
    public float Damage { get; set; }
    public CharacterType CharacterType { get; set; }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Usar CharacterSystemComposer para identificar al personaje y aplicar daño legacy
        var characterSystem = CharacterSystemComposer.Instance;
        var controller = characterSystem?.GetController(other.gameObject);
        bool isFriendlyFire = controller != null && controller.CharacterType == CharacterType;

        if (!isFriendlyFire)
        {
            var health = other.GetComponent<global::Health>();
            if (health != null)
            {
                health.TakeDamage(Damage);
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

