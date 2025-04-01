using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform player;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) { TeleportToSpawn(); }
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
