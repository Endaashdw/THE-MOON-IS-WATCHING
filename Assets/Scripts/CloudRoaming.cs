using UnityEngine;

public class CloudRoaming : MonoBehaviour
{
    [SerializeField] private float minSpeed = 1f; // Minimum speed of clouds
    [SerializeField] private float maxSpeed = 5f; // Maximum speed of clouds
    [SerializeField] private float directionChangeInterval = 3f; // Time interval to randomize movement

    private float speed; // Current speed of the cloud
    private float timeUntilDirectionChange;

    void Start()
    {
        // Initialize random speed
        speed = Random.Range(minSpeed, maxSpeed);
        timeUntilDirectionChange = directionChangeInterval;
    }

    void Update()
    {
        // Move the cloud backward on the Z-axis
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        // Countdown to adjust speed
        timeUntilDirectionChange -= Time.deltaTime;
        if (timeUntilDirectionChange <= 0f)
        {
            RandomizeMovement();
            timeUntilDirectionChange = directionChangeInterval; // Reset the timer
        }
    }

    private void RandomizeMovement()
    {
        // Randomize speed within the range
        speed = Random.Range(minSpeed, maxSpeed);
        Debug.Log("New Speed: " + speed);
    }
}
