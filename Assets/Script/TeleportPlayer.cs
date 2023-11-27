using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public Transform teleportLocation; // Assign the empty GameObject's Transform in the inspector
    public string playerTag = "Player"; // Make sure your player GameObject is tagged with "Player"

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered");
        Debug.Log(other.tag);
        // Check if the colliding object has the correct tag
        if (other.CompareTag(playerTag))
        {
            // Teleport the object that entered the trigger
            Teleport(other.transform);
        }
    }

    // Modified Teleport method to take a Transform as a parameter
    public void Teleport(Transform playerTransform)
    {
        if (teleportLocation != null)
        {
            // Change the player's position to that of the teleport location
            playerTransform.position = teleportLocation.position;
        }
        else
        {
            Debug.LogError("Teleport location has not been assigned.");
        }
    }
}
