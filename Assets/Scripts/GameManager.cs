
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // UI panels
    public GameObject gameOverPanel;
    public GameObject winPanel;

    // Check if the game has ended
    bool isGameEnded = false;

    void Start()
    {
        // Resume normal game time
        Time.timeScale = 1f;

        // Hide both panels
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
    }

    void Update()
    {
        // Allow restart after the game ends
        if (isGameEnded)
        {
            if (Keyboard.current.rKey.wasPressedThisFrame)
            {
                RestartGame();
            }
        }
    }

    // Called when the player dies
    public void GameOver()
    {
        // Do nothing if the game already ended
        if (isGameEnded)
        {
            return;
        }

        isGameEnded = true;

        // Show Game Over screen
        gameOverPanel.SetActive(true);

        // Pause the game
        Time.timeScale = 0f;
    }

    // Called when the player reaches the goal
    public void Win()
    {
        // Do nothing if the game already ended
        if (isGameEnded)
        {
            return;
        }

        isGameEnded = true;

        // Show Win screen
        winPanel.SetActive(true);

        // Pause the game
        Time.timeScale = 0f;
    }

    // Restart the current level
    public void RestartGame()
    {
        // Resume normal game time
        Time.timeScale = 1f;

        // Reload the scene
        string sceneName =
            SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(sceneName);
    }
}
