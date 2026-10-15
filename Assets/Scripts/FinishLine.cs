
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    // Called when an object enters the finish line
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object is Player
        if (other.CompareTag("Player"))
        {
            // Find GameManager
            GameManager gameManager =
                FindFirstObjectByType<GameManager>();

            // Check if GameManager exists
            if (gameManager != null)
            {
                // Player wins the game
                gameManager.Win();
            }
        }
    }
}
