using UnityEngine;

public class Projectile2D : MonoBehaviour
{
    // How long before the projectile destroys itself
    public float lifeTime = 3f;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // Destroy projectile after a few seconds
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        Vector2 dir = rb.linearVelocity;

        if (dir.sqrMagnitude > 0.001f)
        {
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Ignore trigger if it hits player or puppet
        if (other.CompareTag("Player") || other.CompareTag("Puppet"))
        {
            return;
        }
        else if (other.CompareTag("Enemy"))
        {
            if (other.GetComponent<Health>() != null)
            {
                other.GetComponent<Health>().Damage(5);
            }
        }

        // Destroy projectile when it hits something else
        Destroy(gameObject);
    }
}

