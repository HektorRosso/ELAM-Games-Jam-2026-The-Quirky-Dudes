using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    // Movement speed
    public float moveSpeed = 5f;

    // Reference to Rigidbody2D
    private Rigidbody2D rb;

    // Stores movement input
    private Vector2 movement;

    void Start()
    {
        // Get Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input (A/D or Left/Right)
        movement.x = Input.GetAxis("Horizontal");

        // Get input (W/S or Up/Down)
        movement.y = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        // Move the player using physics
        rb.linearVelocity = movement * moveSpeed;
    }
}