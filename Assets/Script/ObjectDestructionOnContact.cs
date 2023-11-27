using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestructionOnContact : MonoBehaviour
{
    [SerializeField] private GameObject destroyer; // Serialized field for the Destroyer object
    [SerializeField] private GameObject destructible; // Serialized field for the Destructible object

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // OnCollisionEnter is called when this GameObject collides with another GameObject
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is the specific destroyer
        if (collision.gameObject == destroyer)
        {
            // Check if the destructible object is not null and is active in the scene
            if (destructible != null && destructible.activeInHierarchy)
            {
                // Destroy the destructible object
                Destroy(destructible);
            }
        }
    }
}
