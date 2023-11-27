using UnityEngine;

public class LaserBehavior : MonoBehaviour
{
    public float maxLaserDistance = 100f;
    public LayerMask laserCollidableLayers; // Set this in the inspector to the layers the laser should collide with

    private LineRenderer lineRenderer;
    private BoxCollider boxCollider; // Reference to the BoxCollider

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        boxCollider = GetComponent<BoxCollider>(); // Get the BoxCollider component
        AdjustLaser(maxLaserDistance);
    }

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, maxLaserDistance, laserCollidableLayers))
        {
            AdjustLaser(hit.distance * 10);
        }
        else
        {
            AdjustLaser(maxLaserDistance);
        }
    }

    void AdjustLaser(float distance)
    {
        lineRenderer.SetPosition(1, new Vector3(0, 0, distance));

        // Assuming the collider's size.x is the width you want to adjust
        // The size is set to distance * 10 as per your request
        boxCollider.size = new Vector3(boxCollider.size.x, boxCollider.size.y, distance);

        // You might need to adjust the collider's center if the pivot is at one end of the laser
        boxCollider.center = new Vector3(boxCollider.center.x, boxCollider.center.y, distance /2);
    }
}
