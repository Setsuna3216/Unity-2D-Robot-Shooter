
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Enemy health
    public int health = 3;

    // Reference to Player
    public Transform player;

    // Enemy bullet prefab
    public GameObject enemyBulletPrefab;

    // Time between shots
    public float shootInterval = 2f;

    // Maximum shooting distance
    public float shootRange = 8f;

    // Shooting timer
    float shootTimer = 0f;

    void Start()
    {
        // Find Player using the Player tag
        GameObject playerObject =
            GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    void Update()
    {
        // Stop if Player does not exist
        if (player == null)
        {
            return;
        }

        // Calculate horizontal distance to Player
        float distance =
            player.position.x - transform.position.x;

        // Check if Player is within shooting range
        if (Mathf.Abs(distance) <= shootRange)
        {
            // Count time
            shootTimer = shootTimer + Time.deltaTime;

            // Shoot every 2 seconds
            if (shootTimer >= shootInterval)
            {
                Shoot();

                // Reset timer
                shootTimer = 0f;
            }
        }
        else
        {
            // Reset timer when Player leaves range
            shootTimer = 0f;
        }
    }

    // Create a bullet and shoot toward Player
    void Shoot()
    {
        // Default direction is right
        int direction = 1;

        // If Player is on the left, shoot left
        if (player.position.x < transform.position.x)
        {
            direction = -1;
        }

        // Set bullet spawn position
        Vector3 spawnPosition = new Vector3(
            transform.position.x + direction * 0.8f,
            transform.position.y,
            0
        );

        // Create enemy bullet
        GameObject newBullet = Instantiate(
            enemyBulletPrefab,
            spawnPosition,
            Quaternion.identity
        );

        // Get EnemyBullet script
        EnemyBullet bulletScript =
            newBullet.GetComponent<EnemyBullet>();

        // Set bullet direction
        bulletScript.SetDirection(direction);
    }

    // Called when enemy takes damage
    public void TakeDamage(int damage)
    {
        // Reduce enemy health
        health = health - damage;

        Debug.Log("Enemy HP: " + health);

        // Check if enemy is dead
        if (health <= 0)
        {
            Die();
        }
    }

    // Called when enemy dies
    void Die()
    {
        // Find ScoreManager
        ScoreManager scoreManager =
            FindFirstObjectByType<ScoreManager>();

        // Add score if ScoreManager exists
        if (scoreManager != null)
        {
            scoreManager.AddScore(100);
        }

        // Destroy enemy
        Destroy(gameObject);
    }
}
