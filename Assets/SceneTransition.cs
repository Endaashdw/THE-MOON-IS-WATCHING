using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : SceneLoader
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the player entered the zone
        if (other.CompareTag("Player")) // Ensure the player GameObject has the "Player" tag
        {
            StartCoroutine(DelayedSceneLoad());
        }
    }
}
