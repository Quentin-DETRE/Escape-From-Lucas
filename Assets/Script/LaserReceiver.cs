using UnityEngine;

public class LaserReceiver : MonoBehaviour
{
    public bool isLaserContact = true; // Assume the laser starts in contact

    private void OnTriggerStay(Collider other)
    {
        // Check if the collider that stays is the laser's collider
        if (other.GetComponent<LaserBehavior>() != null)
        {
            // The laser is currently in contact with the receiver
            isLaserContact = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the collider that exited is the laser's collider
        if (other.GetComponent<LaserBehavior>() != null)
        {
            // The laser is no longer in contact with the receiver
            isLaserContact = false;
        }
    }
}
