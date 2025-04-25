using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/**
    Author: Elysa Hines & Kalia Brown
    Date Created: 3/1/2025
    Date Last Updated: 4/16/2025
    Summary: implements the player's movement within the cafe
 */

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] private float speedForce = 1000f; // Movement speed multiplier

    private Vector2 movementInput;       // Stores the current movement input
    private Rigidbody rb;


    void Start()
    {
        
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        // // Hide and lock the cursor for a better experience
        // Cursor.visible = false;
        // Cursor.lockState = CursorLockMode.Locked;
    }

    // This method is called automatically when the "Move" action is performed
    public void OnMove(InputValue value) { 
        movementInput = value.Get<Vector2>();
        // Debug.Log("Move Input: " + movementInput);

    }


    private void FixedUpdate()
    {
        // Calculate movement vector and move the player
        Vector3 direction = new Vector3(movementInput.x, 0, movementInput.y).normalized;
        //Debug.Log("Calculated Direction: " + direction);
        Vector3 localDirection = transform.forward * direction.z + transform.right * direction.x;
        Vector3 targetPos = rb.position + localDirection * speedForce * Time.fixedDeltaTime;
        rb.MovePosition(targetPos);

        
    }
}
