using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] private float speedForce = 1000f; // Movement speed multiplier
    [SerializeField] private float rotationForce = 100f;  // Rotation speed multiplier

    private Vector2 movementInput;       // Stores the current movement input
    private Vector2 lookInput;           // Stores the current look input
    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Awake()
    {
        // Hide and lock the cursor for a better experience
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // This method is called automatically when the "Move" action is performed
    public void OnMove(InputValue value) { movementInput = value.Get<Vector2>(); }

    // This method is called automatically when the "Look" action is performed
    public void OnLook(InputValue value) { lookInput = value.Get<Vector2>(); }

    private void FixedUpdate()
    {
        // Calculate movement vector and move the player
        Vector3 force = new Vector3(movementInput.x, 0, movementInput.y) * speedForce * Time.deltaTime;
        rb.AddRelativeForce(force);

        // Apply rotation based on horizontal mouse movement
        float torque = lookInput.x * rotationForce * Time.deltaTime;
        rb.AddRelativeTorque(0, torque, 0);
    }
}