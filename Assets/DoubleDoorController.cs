using UnityEngine;

public class DoubleDoorController : MonoBehaviour
{
    public GameObject leftDoorPivot;
    public GameObject rightDoorPivot;

    public float openAngle = 90f;
    public float openingSpeed = 2f;
    private bool isOpening = false;

    void Update()
    {
        if (isOpening)
        {
            OpenDoors();
        }
    }

    public void TriggerDoorOpen()
    {
        isOpening = true;
    }

    private void OpenDoors()
    {
        if (leftDoorPivot.transform.localEulerAngles.y < openAngle)
        {
            // Rotate the left door
            leftDoorPivot.transform.localEulerAngles = new Vector3(
                leftDoorPivot.transform.localEulerAngles.x,
                Mathf.MoveTowards(leftDoorPivot.transform.localEulerAngles.y, openAngle, Time.deltaTime * openingSpeed),
                leftDoorPivot.transform.localEulerAngles.z);

            // Rotate the right door in the opposite direction
            rightDoorPivot.transform.localEulerAngles = new Vector3(
                rightDoorPivot.transform.localEulerAngles.x,
                Mathf.MoveTowards(rightDoorPivot.transform.localEulerAngles.y, -openAngle, Time.deltaTime * openingSpeed),
                rightDoorPivot.transform.localEulerAngles.z);
        }
        else
        {
            isOpening = false;
        }
    }
}
