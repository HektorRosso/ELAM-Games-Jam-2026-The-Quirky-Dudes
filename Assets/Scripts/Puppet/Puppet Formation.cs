using UnityEngine;

public class PuppetFormation2D : MonoBehaviour
{
    // Reference to the main player
    public Transform player;

    // Offset from the player
    // Example:
    // top-left = (-1.5f, 1.5f)
    // top-right = (1.5f, 1.5f)
    // bottom-left = (-1.5f, -1.5f)
    // bottom-right = (1.5f, -1.5f)
    public Vector2 offset;

    // How fast the puppet moves to its spot
    public float followSpeed = 8f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (player == null) return;

        // Find the target position based on player position + assigned offset
        Vector2 targetPosition = (Vector2)player.position + offset;

        // Smoothly move puppet to its formation position
        Vector2 newPosition = Vector2.Lerp(rb.position, targetPosition, followSpeed * Time.fixedDeltaTime);

        rb.MovePosition(newPosition);
    }
}

