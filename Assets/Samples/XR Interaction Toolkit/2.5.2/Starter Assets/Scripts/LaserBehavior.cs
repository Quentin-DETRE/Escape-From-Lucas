using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class LaserBehavior : MonoBehaviour
{
    [SerializeField] private string notCuttableTag = "NotCuttable";
    private LineRenderer lineRenderer;
    private BoxCollider boxCollider;
    private float LineLength;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        boxCollider = GetComponent<BoxCollider>();
        LineLength = lineRenderer.GetPosition(lineRenderer.positionCount - 1).z;
    }

    void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag(notCuttableTag))
        {

            float distance = Mathf.Abs(other.transform.position.z - transform.position.z);

            AdjustLineRendererSize(distance);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag(notCuttableTag))
        {
            lineRenderer.SetPosition(1, new Vector3(0, 0, LineLength));
            boxCollider.size = new Vector3(0.1f, 0.1f, LineLength);
            boxCollider.center = new Vector3(boxCollider.center.x, boxCollider.center.y, LineLength / 2f);
        }
    }

    void AdjustLineRendererSize(float distance)
    {
        lineRenderer.SetPosition(1, new Vector3(0, 0, distance * 9.1f));
        boxCollider.size = new Vector3(0.1f, 0.1f, distance * 9.5f);
        boxCollider.center = new Vector3(boxCollider.center.x, boxCollider.center.y, distance * 4.7f);
    }
}
