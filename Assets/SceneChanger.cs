using UnityEngine;

public class SceneChanger : SceneLoader
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        StartCoroutine(DelayedSceneLoad());
    }
}
