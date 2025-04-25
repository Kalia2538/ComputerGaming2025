using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controller;

/**
    Author: Kalia Brown
    Date Created: 3/1/2025
    Date Last Updated: 4/16/2025
    Summary: Placeholder code to simulate movement of customer in and
        out of the cafe 
 */

public class CustomerInteraction : MonoBehaviour
{
    // locations for ordering
    public GameObject orderPoint;    
    public GameObject startPoint;
    public GameObject orderLoc; // for the paper order

    // instantiated prefabs
    private GameObject orderObj;
    private GameObject customer;

    //prefabs
    public GameObject customerPrefab;
    public GameObject order;

    public float speed;
    private Rigidbody custRigidBody;

    private bool inRoutine = false;
    



    // Start is called before the first frame update
    void Start()
    {
        // instantiate customer and rigid body
        customer = Instantiate(customerPrefab, startPoint.transform.position, Quaternion.identity);
        DontDestroyOnLoad(customer);
        CharacterMover mover = customer.GetComponent<CharacterMover>(); 
        // start ordering process
        StartCoroutine(OrderProcess(mover));
    }


    IEnumerator EnterScreen(CharacterMover mover)
    {
        // customer moves towards specified location
        while (Vector3.Distance(customer.transform.position, orderPoint.transform.position) > 0.1f)
        {

            Vector3 direction = (orderPoint.transform.position - customer.transform.position).normalized;
            Vector3 localDir = customer.transform.InverseTransformDirection(direction);
            Vector2 movementInput = new Vector2(localDir.x, localDir.z);
            mover.SetInput(movementInput, orderPoint.transform.position, false, false);
            
            yield return null;

        }
        // stops customer movement
        mover.SetInput(Vector2.zero, mover.transform.position, false, false);
        // wait for click
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

    }

    IEnumerator TakingOrder(CharacterMover mover)
    {
        // order "pop-up"
        orderObj = Instantiate(order, orderLoc.transform.position, Quaternion.identity);

        // wait time so that click from before doesn't collide with this one
        yield return new WaitForSeconds(0.5f);
        // wait for click
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
    }


    
    IEnumerator ExitingScreen(CharacterMover mover)
    {

        Destroy(orderObj);
        // customer moves towards specified location
        while (Vector3.Distance(customer.transform.position, startPoint.transform.position) > 0.1f)
        {

            Vector3 direction = (startPoint.transform.position - customer.transform.position).normalized;
            Vector3 localDirection = customer.transform.InverseTransformDirection(direction);
            Vector2 movementInput = new Vector2(localDirection.x, localDirection.z);

            mover.SetInput(movementInput, startPoint.transform.position, false, false);
            yield return null;

        }








        // customer moving away from the counter
        while (Vector3.Distance(customer.transform.position, startPoint.transform.position) > 0.1f)
        {
            Vector3 direction = (startPoint.transform.position - customer.transform.position).normalized;
            custRigidBody.velocity = direction * speed;
            yield return null;
        }

        custRigidBody.velocity = Vector3.zero;
        yield return null;
    }

    IEnumerator OrderProcess(CharacterMover mover)
    {
        if (!inRoutine) { 
            inRoutine = true;            
            yield return EnterScreen(mover);
            
            yield return TakingOrder(mover);
            
            yield return ExitingScreen(mover);
            Destroy(customer);
            
            customer = Instantiate(customerPrefab, startPoint.transform.position, Quaternion.identity);
            StartCoroutine(OrderProcess(mover));
        }
    }

    //private void FixedUpdate()
    //{
    //    if (!inRoutine)
    //    {
    //        StartCoroutine(OrderProcess());
    //    }
    //}
}
