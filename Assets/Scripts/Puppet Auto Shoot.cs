using UnityEngine;

public class PuppetAutoShoot2D : MonoBehaviour
{
    // Projectile prefab to spawn
    public GameObject projectilePrefab;

    // Where the projectile comes out from
    public Transform firePoint;

    // Time between shots
    public float shootInterval = 1f;

    // Speed of the projectile
    public float projectileSpeed = 8f;

    // Direction to shoot in
    // Example: right = (1, 0), up = (0, 1)
    public Vector2 shootDirection = Vector2.right;

    // Internal timer
    private float shootTimer;

    void Update()
    {
        // Count down
        shootTimer -= Time.deltaTime;

        // When timer reaches 0, shoot
        if (shootTimer <= 0f)
        {
            Shoot();
            shootTimer = shootInterval;
        }
    }

    void Shoot()
    {
        // Safety checks
        if (projectilePrefab == null || firePoint == null)
            return;

        // Spawn projectile at fire point position
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        // Get Rigidbody2D from projectile
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            // Move projectile in chosen direction
            rb.linearVelocity = shootDirection.normalized * projectileSpeed;
        }
    }
}

