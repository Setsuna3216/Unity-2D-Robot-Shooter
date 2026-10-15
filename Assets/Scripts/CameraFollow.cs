
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Reference to the player
    public Transform player;

    // Runs after Update()
    void LateUpdate()
    {
        // Stop if the player is missing
        if (player == null)
        {
            return;
        }

        // Get the player's X position
        float x = player.position.x;

        // Keep the camera from moving left of the start
        if (x < 0)
        {
            x = 0;
        }

        // Move the camera horizontally
        // Keep Y = 0 and Z = -10
        transform.position = new Vector3(x, 0, -10);
    }
}
