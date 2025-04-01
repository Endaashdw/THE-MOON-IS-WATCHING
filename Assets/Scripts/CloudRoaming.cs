using UnityEngine;

public class CloudRoaming : MonoBehaviour
{
    [SerializeField] private float minSpeed = 1f; // Minimum speed of clouds
    [SerializeField] private float maxSpeed = 5f; // Maximum speed of clouds
    [SerializeField] private float directionChangeInterval = 3f; // Time interval to change direction

    private float speed; // Current speed of the cloud
    private Vector3 randomDirection; // Current movement direction
    private float timeUntilDirectionChange;

    void Start()
    {
        // Initialize random speed and direction
        speed = Random.Range(minSpeed, maxSpeed);
        GenerateRandomDirection();

        // Initialize the timer
        timeUntilDirectionChange = directionChangeInterval;
    }

    void Update()
    {
        // Move the cloud in the current random direction
        transform.Translate(randomDirection * speed * Time.deltaTime);

        // Countdown to direction change
        timeUntilDirectionChange -= Time.deltaTime;
        if (timeUntilDirectionChange <= 0f)
        {
            GenerateRandomDirection();
            timeUntilDirectionChange = directionChangeInterval; // Reset the timer
        }
    }

    private void GenerateRandomDirection()
    {
        // Generate a random 3D direction but keep Y value constant
        randomDirection = new Vector3(
            Random.Range(-1f, 1f), // Random X direction
            0f,                   // Keep Y constant (no vertical movement)
            Random.Range(-1f, 1f) // Random Z direction
        ).normalized; // Normalize to ensure consistent speed

        Debug.Log("New Direction: " + randomDirection);
    }
}
