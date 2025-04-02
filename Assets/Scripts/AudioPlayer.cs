using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private float interval = 3f; // Time in seconds between plays
    private AudioSource audioSource; // Reference to the AudioSource component
    private float timer; // Internal timer to track elapsed time

    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("No AudioSource found! Please attach an AudioSource component to this GameObject.");
        }

        // Initialize the timer
        timer = interval;
    }

    void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // Check if the interval has passed
        if (timer >= interval)
        {
            PlayAudio(); // Play the audio
            timer = 0f;  // Reset the timer
        }
    }

    private void PlayAudio()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
