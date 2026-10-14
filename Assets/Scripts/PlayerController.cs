
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Player movement and jump speed
    public float moveSpeed = 5f;
    public float jumpSpeed = 10f;

    // Bullet prefab used for shooting
    public GameObject bulletPrefab;

    // Player's physics component
    Rigidbody2D rb;

    // Check if the player is on the ground
    bool onGround = false;

    // 1 = right, -1 = left
    int facingDirection = 1;

    // Runs once when the game starts
    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    // Runs every frame
    void Update()
    {
        // Default: no horizontal movement
        float move = 0;

        // Move left when A is pressed
        if (Keyboard.current.aKey.isPressed)
        {
            move = -1;
            facingDirection = -1;
        }

        // Move right when D is pressed
        if (Keyboard.current.dKey.isPressed)
        {
            move = 1;
            facingDirection = 1;
        }

        // Update horizontal speed
        // Keep the current vertical speed
        rb.linearVelocity = new Vector2(
            move * moveSpeed,
            rb.linearVelocity.y
        );

        // Jump when Space is pressed and player is grounded
        if (Keyboard.current.spaceKey.wasPressedThisFrame && onGround)
        {
            // Keep horizontal speed and jump upward
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                jumpSpeed
            );

            // Player is now in the air
            onGround = false;
        }

        // Shoot when J is pressed
        if (Keyboard.current.jKey.wasPressedThisFrame)
        {
            Shoot();
        }
    }

    // Create and shoot a bullet
    void Shoot()
    {
        // Spawn the bullet in front of the player
        Vector3 spawnPosition = new Vector3(
            transform.position.x + facingDirection * 0.8f,
            transform.position.y,
            0
        );

        // Create a new bullet from the prefab
        GameObject newBullet = Instantiate(
            bulletPrefab,
            spawnPosition,
            Quaternion.identity
        );

        // Get the Bullet script from the new bullet
        Bullet bulletScript = newBullet.GetComponent<Bullet>();

        // Set the bullet's direction
        bulletScript.SetDirection(facingDirection);
    }

    // Called when the player starts touching an object
    void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the object is Ground
        if (other.gameObject.name == "Ground")
        {
            onGround = true;
        }
    }

    // Called when the player stops touching an object
    void OnCollisionExit2D(Collision2D other)
    {
        // Check if the player left the Ground
        if (other.gameObject.name == "Ground")
        {
            onGround = false;
        }
    }
}
