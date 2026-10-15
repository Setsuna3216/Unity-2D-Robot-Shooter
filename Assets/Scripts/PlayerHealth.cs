
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    // Player starts with 5 HP
    public int health = 5;

    // Text that displays player's HP
    public TextMeshProUGUI healthText;

    // Runs once when the game starts
    void Start()
    {
        // Display starting HP
        UpdateHealth();
    }

    // Called when player takes damage
    public void TakeDamage(int damage)
    {
        // Do nothing if player is already dead
        if (health <= 0)
        {
            return;
        }

        // Reduce player's HP
        health = health - damage;

        // Prevent HP from going below 0
        if (health < 0)
        {
            health = 0;
        }

        // Print current HP to Console
        Debug.Log("Player HP: " + health);

        // Update HP on screen
        UpdateHealth();

        // Check if player is dead
        if (health <= 0)
        {
            Die();
        }
    }

    // Update HP text
    void UpdateHealth()
    {
        healthText.text = "HP: " + health;
    }

    // Called when player dies

    void Die()
    {
        // Print Game Over to Console
        Debug.Log("Game Over");

        // Find GameManager in the scene
        GameManager gameManager =
            FindFirstObjectByType<GameManager>();

        // Check if GameManager exists
        if (gameManager != null)
        {
            // Tell GameManager to end the game
            gameManager.GameOver();
        }
    }

}
