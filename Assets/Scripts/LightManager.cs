using UnityEngine;
using System.Collections.Generic;

public class LightManager : MonoBehaviour
{
    public static LightManager Instance;
    private List<Light> allLights = new List<Light>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        allLights.AddRange(FindObjectsByType<Light>(FindObjectsSortMode.None));
    }

    public List<Light> GetLights() => allLights;
}
