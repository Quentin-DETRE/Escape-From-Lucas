using System.Collections;
using UnityEngine;

public class OpenDoorWithKey : MonoBehaviour
{
    [SerializeField] private GameObject key; // Serialized field for the key object
    [SerializeField] private float openAngle = 90.0f; // The angle the door should open to
    [SerializeField] private float openSpeed = 2.0f; // The speed at which the door should open

    private bool isOpening = false; // Flag to control the opening of the door

    // OnTriggerEnter is called when another GameObject enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the key and if the door is not already opening
        if (other.gameObject == key && !isOpening)
        {
            StartCoroutine(OpenDoor());
        }
    }

    private IEnumerator OpenDoor()
    {
        isOpening = true; // Set the flag to indicate the door is opening
        Quaternion startRotation = transform.rotation; // Store the initial rotation
        Quaternion endRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + openAngle, transform.eulerAngles.z); // Calculate the final rotation

        float t = 0.0f;
        while (t < 1.0f)
        {
            t += Time.deltaTime * openSpeed; // Increment t based on the open speed and time passed
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, t); // Slerp the rotation towards the end rotation
            yield return null; // Wait until the next frame
        }

        isOpening = false; // Set the flag to indicate the door has finished opening
    }
}
