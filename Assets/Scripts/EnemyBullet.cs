
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Bullet movement speed
    public float speed = 5f;

    void Start()
    {
        // Destroy the bullet after 4 seconds
        Destroy(gameObject, 4f);
    }

    // Set bullet direction
    // 1 = right, -1 = left
    public void SetDirection(int direction)
    {
        // Get Rigidbody2D
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        // Move the bullet horizontally
        rb.linearVelocity = new Vector2(
            speed * direction,
            0
        );
    }

    // Called when the bullet hits a collider
    void OnTriggerEnter2D(Collider2D other)
    {
        // Try to find PlayerHealth
        PlayerHealth player =
            other.GetComponent<PlayerHealth>();

        // Check if the bullet hit the player
        if (player != null)
        {
            // Deal 1 damage
            player.TakeDamage(1);

            // Remove the bullet
            Destroy(gameObject);
        }
    }
}
