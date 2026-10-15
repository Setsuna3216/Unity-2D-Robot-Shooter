
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // Player's current score
    public int score = 0;

    // UI text that displays the score
    public TextMeshProUGUI scoreText;

    // Runs once when the game starts
    void Start()
    {
        UpdateScore();
    }

    // Add points to the player's score
    public void AddScore(int points)
    {
        score = score + points;

        UpdateScore();
    }

    // Update the score displayed on screen
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}
