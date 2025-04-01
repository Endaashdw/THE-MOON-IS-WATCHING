using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string sceneName; // Name of the scene to load
    [SerializeField] private float delay = 3f; // Delay in seconds before loading the scene

    public void LoadSceneWithDelay()
    {
        StartCoroutine(DelayedSceneLoad());
    }

    protected IEnumerator DelayedSceneLoad()
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        SceneManager.LoadScene(sceneName); // Load the scene
    }
}
