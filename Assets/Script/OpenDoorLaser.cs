using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorLaser : MonoBehaviour
{
    public LaserReceiver receiver1;
    public LaserReceiver receiver2;
    public LaserReceiver receiver3;

    public GameObject leftDoorPivot;
    public GameObject rightDoorPivot;

    public float openAngle = 90f;
    public float openingSpeed = 2f;
    private bool isOpening = false;

    void Update()
    {
        if (!receiver1.isLaserContact && !receiver2.isLaserContact && !receiver3.isLaserContact && !isOpening)
        {
            isOpening = true;
        }

        if (isOpening)
        {
            OpenTheDoor();
        }
    }

    void OpenTheDoor()
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
    