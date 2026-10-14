
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Enemy health
    public int health = 3;

    // Enemy movement speed
    public float moveSpeed = 2f;

    // Distance at which the enemy stops moving
    public float stopDistance = 1.3f;

    // Reference to the player
    public Transform player;

    // Enemy physics component
    Rigidbody2D rb;

    // Runs once when the game starts

    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();

        // Find the Player using its tag
        GameObject playerObject =
            GameObject.FindGameObjectWithTag("Player");

        // Check if the Player was found
        if (playerObject != null)
        {
            // Save the Player's Transform
            player = playerObject.transform;

            Debug.Log("Enemy found Player!");
        }
        else
        {
            Debug.Log("Enemy cannot find Player!");
        }
    }

    // Runs at a fixed interval for physics
    void FixedUpdate()
    {
        // Stop if the player is not assigned
        if (player == null)
        {
            return;
        }

        // Calculate the distance to the player
        float distance = player.position.x - transform.position.x;

        // Default: enemy does not move
        float move = 0;

        // Player is on the right
        if (distance > stopDistance)
        {
            move = 1;
        }
        // Player is on the left
        else if (distance < -stopDistance)
        {
            move = -1;
        }

        // Move left or right
        // Keep the current vertical speed
        rb.linearVelocity = new Vector2(
            move * moveSpeed,
            rb.linearVelocity.y
        );
    }

    // Called when the enemy takes damage
    public void TakeDamage(int damage)
    {
        // Reduce health
        health = health - damage;

        // Print remaining health
        Debug.Log("Enemy HP: " + health);

        // Check if enemy is dead
        if (health <= 0)
        {
            Die();
        }
    }

    // Destroy the enemy
    void Die()
    {
        Destroy(gameObject);
    }
}
