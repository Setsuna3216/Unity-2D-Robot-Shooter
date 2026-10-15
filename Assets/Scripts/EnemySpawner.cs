
using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    // Enemy prefab
    public GameObject enemyPrefab;

    // Reference to Player
    public Transform player;

    // Distance before enemy appears
    public float spawnDistance = 7f;

    // Queue stores enemy spawn positions
    Queue<float> spawnQueue = new Queue<float>();

    void Start()
    {
        // Find Player using its tag
        GameObject playerObject =
            GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }

        // Add enemy positions to the queue
        spawnQueue.Enqueue(10f);
        spawnQueue.Enqueue(18f);
        spawnQueue.Enqueue(26f);
    }

    void Update()
    {
        // Stop if Player is missing
        if (player == null)
        {
            return;
        }

        // Check if there are enemies left to spawn
        if (spawnQueue.Count > 0)
        {
            // Look at the next spawn position
            float nextPosition = spawnQueue.Peek();

            // Check if Player is close enough
            if (player.position.x >= nextPosition - spawnDistance)
            {
                // Remove the position from the queue
                float spawnX = spawnQueue.Dequeue();

                // Set enemy spawn position
                Vector3 spawnPosition = new Vector3(
                    spawnX,
                    -2.25f,
                    0f
                );

                // Create the enemy
                Instantiate(
                    enemyPrefab,
                    spawnPosition,
                    Quaternion.identity
                );
            }
        }
    }
}
