using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBlocking : MonoBehaviour
{
    public LayerMask playerLayer;
    private CharacterController characterController;
    private Transform player;

    private void Start()
    {
        // Assuming the player has a CharacterController component
        characterController = GameObject.FindWithTag("Player").GetComponent<CharacterController>();
        player = characterController.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // Calculate the direction from the player to the laser beam
            Vector3 directionToLaser = (transform.position - player.position).normalized;

            // Calculate the new position to block movement towards the laser beam
            Vector3 newPosition = player.position + Vector3.ProjectOnPlane(directionToLaser, Vector3.up) * Time.deltaTime;

            // Set the player's position to the new position
            characterController.Move(newPosition - player.position);

            Debug.Log("Player hit by laser beam! Movement towards the laser blocked.");
        }
    }
}
