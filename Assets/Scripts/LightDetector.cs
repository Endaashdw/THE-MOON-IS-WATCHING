using UnityEngine;
using TMPro;

public class LightDetector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI reminderText;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform player;
    [SerializeField] private Transform playerPackage;
    [SerializeField] private float lightThreshold = 0.5f;
    private Light[] allLights;
    private Light directionalLight;
    private float lightLevel;

    void Start()
    {
        allLights = FindObjectsByType<Light>(FindObjectsSortMode.None);
        foreach (Light light in allLights)
        {
            if (light.type == LightType.Directional)
            {
                directionalLight = light;
                break; //Only checks for one directional light 
            }
        }
    }

    void Update()
    {
        lightLevel = GetTotalLightIntensity();

        if (lightLevel > lightThreshold)
        {
            Debug.Log("✅ The MOON is watching!"); // Clear message
            ShowCanvasText(true);
        }
        else
        {
            Debug.Log("❌ The MOON cannot see you.");
            ShowCanvasText(false);
        }

        Debug.Log("Light Level: " + lightLevel);
        Debug.Log("Light Threshold: " + lightThreshold);
        Debug.Log("Condition Passed: " + (lightLevel > lightThreshold));

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Pressed E!");
            TeleportToSpawn();
        }
    }


    float GetTotalLightIntensity()
    {
        float intensity = 0f;

        // Add Directional Light Intensity (if it exists)
        if (directionalLight != null && IsInDirectSunlight())
        {
            intensity += directionalLight.intensity;
        }

        // Check all Point/Spot Lights
        foreach (Light light in allLights)
        {
            if (!light.isActiveAndEnabled || light.type == LightType.Directional) continue;

            Vector3 dirToLight = (light.transform.position - player.position).normalized;
            RaycastHit hit;

            // Check if the light reaches the player (no obstacles in the way)
            if (!Physics.Raycast(player.position, dirToLight, out hit) || hit.collider.gameObject == light.gameObject)
            {
                float distance = Vector3.Distance(player.position, light.transform.position);
                float attenuation = Mathf.Clamp01(1f - (distance / light.range));
                intensity += light.intensity * attenuation;
            }
        }

        return intensity;
    }

    bool IsInDirectSunlight()
    {
        if (directionalLight == null) return false;

        Vector3 lightDirection = -directionalLight.transform.forward; // Opposite of light's forward direction
        Vector3 rayOrigin = player.position + Vector3.up * 0.2f; // Raise the raycast slightly

        RaycastHit hit;

        // If no obstacle between player and sun, they are in direct sunlight
        if (!Physics.Raycast(rayOrigin, lightDirection, out hit, Mathf.Infinity))
        {
            return true;
        }
        
        return false;
    }

    private void ShowCanvasText(bool value)
    {
        reminderText.gameObject.SetActive(value);
    }

    private void TeleportToSpawn()
    {
        CharacterController characterController = player.GetComponent<CharacterController>();

        if (characterController != null)
        {
            // Temporarily disable the CharacterController
            characterController.enabled = false;

            // Set the player's position to the spawn point
            player.position = spawnPoint.position;

            // Re-enable the CharacterController
            characterController.enabled = true;

            Debug.Log("Player teleported to spawn point!");
        }
        else
        {
            Debug.LogError("CharacterController not found on the player object!");
        }
    }
}
