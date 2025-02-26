using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] private float speedForce = 1000f; //movement speed multiplier based for force
    [SerializeField] private float rotationForce = 100f;  //rotation speed multiplier based for force

    private Vector2 movementInput;       //stores current movement input
    private Vector2 lookInput;           //stores the current look input
    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Awake()
    {
        //hides and locsk the cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    //called automatically when the "Move" action is performed
    public void OnMove(InputValue value) { movementInput = value.Get<Vector2>(); }

    //called automatically when the "Look" action is performed
    public void OnLook(InputValue value) { lookInput = value.Get<Vector2>(); }

    private void FixedUpdate()
    {
        //calculates movement vector and move the player
        Vector3 force = new Vector3(movementInput.x, 0, movementInput.y) * speedForce * Time.deltaTime;
        rb.AddRelativeForce(force);

        //applies rotation based on horizontal mouse movement
        float torque = lookInput.x * rotationForce * Time.deltaTime;
        rb.AddRelativeTorque(0, torque, 0);
    }
}