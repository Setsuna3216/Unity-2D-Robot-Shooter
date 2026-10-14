
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Bullet movement speed
    public float speed = 10f;

    // Runs when the bullet is created
    void Start()
    {
        // Destroy the bullet after 3 seconds
        Destroy(gameObject, 3f);
    }

    // Set the bullet's movement direction
    // 1 = right, -1 = left
    public void SetDirection(int direction)
    {
        // Get the Rigidbody2D component
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        // Move the bullet left or right
        rb.linearVelocity = new Vector2(
            speed * direction,
            0
        );
    }

    // Called when the bullet enters a trigger collider
    void OnTriggerEnter2D(Collider2D other)
    {
        // Try to find an Enemy script
        Enemy enemy = other.GetComponent<Enemy>();

        // Check if the object is an enemy
        if (enemy != null)
        {
            // Deal 1 damage to the enemy
            enemy.TakeDamage(1);

            // Destroy the bullet after hitting the enemy
            Destroy(gameObject);
        }
    }
}
