using UnityEngine;

public class PuppetFollow2D : MonoBehaviour
{
    // Reference to the player
    public Transform player;

    // Distance the puppet stays behind the player
    public float followDistance = 1.5f;

    // How fast the puppet follows
    public float followSpeed = 5f;

    // Store last direction player moved
    private Vector2 lastMoveDirection = Vector2.down;

    // Optional: Rigidbody2D for smoother movement
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player == null) return;

        // Get player input direction
        Vector2 inputDirection = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );

        // Update direction only when moving
        if (inputDirection != Vector2.zero)
        {
            lastMoveDirection = inputDirection.normalized;
        }
    }

    void FixedUpdate()
    {
        if (player == null) return;

        // Calculate position behind player
        Vector2 targetPosition = (Vector2)player.position - lastMoveDirection * followDistance;

        // Smooth movement toward target
        Vector2 newPosition = Vector2.Lerp(
            rb.position,
            targetPosition,
            followSpeed * Time.fixedDeltaTime
        );

        rb.MovePosition(newPosition);
    }
}