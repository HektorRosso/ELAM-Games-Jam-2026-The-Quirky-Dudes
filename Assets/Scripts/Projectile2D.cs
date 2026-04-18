using UnityEngine;

public class Projectile2D : MonoBehaviour
{
    // How long before the projectile destroys itself
    public float lifeTime = 3f;

    void Start()
    {
        // Destroy projectile after a few seconds
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Ignore trigger if it hits player or puppet
        if (other.CompareTag("Player") || other.CompareTag("Puppet"))
            return;

        // Destroy projectile when it hits something else
        Destroy(gameObject);
    }
}

