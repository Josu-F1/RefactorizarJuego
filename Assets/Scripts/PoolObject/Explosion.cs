using UnityEngine;

public class Explosion : PoolObject
{
    public float Damage { get; set; }
    public CharacterType CharacterType { get; set; }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Usar CharacterSystemComposer
        var characterSystem = CharacterSystemComposer.Instance;
        if (characterSystem != null)
        {
            var controller = characterSystem.GetController(other.gameObject);
            if (controller != null && controller.CharacterType != CharacterType)
            {
                controller.NotifyEvent(CharacterEvent.HealthDepleted, Damage);
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

