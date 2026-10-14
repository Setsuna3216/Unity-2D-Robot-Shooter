
using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    // Enemy prefab to spawn
    public GameObject enemyPrefab;

    // Time between enemy spawns
    public float spawnInterval = 3f;

    // Timer
    float timer = 0f;

    // Queue stores the spawn directions
    // -1 = left, 1 = right
    Queue<int> spawnQueue = new Queue<int>();

    void Start()
    {
        // Add spawn directions to the queue
        spawnQueue.Enqueue(-1);
        spawnQueue.Enqueue(1);
    }

    void Update()
    {
        // Count the time since the last spawn
        timer = timer + Time.deltaTime;

        // Check if 3 seconds have passed
        if (timer >= spawnInterval)
        {
            // Reset the timer
            timer = 0f;

            // Get the next spawn direction
            int side = spawnQueue.Dequeue();

            // Choose left or right spawn position
            Vector3 spawnPosition = new Vector3(
                side * 7f,
                -2.25f,
                0f
            );

            // Create a new enemy
            Instantiate(
                enemyPrefab,
                spawnPosition,
                Quaternion.identity
            );

            // Put the direction back into the queue
            spawnQueue.Enqueue(side);
        }
    }
}
