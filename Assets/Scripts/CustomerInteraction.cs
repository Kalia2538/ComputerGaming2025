using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controller;

/**
    Author: Kalia Brown
    Date Created: 3/1/2025
    Date Last Updated: 5/6/2025
    Summary: Placeholder code to simulate movement of customer in and
        out of the cafe 
 */



public class CustomerInteraction : MonoBehaviour {
    [Header("Location points")]
    public GameObject orderPoint;    
    public GameObject startPoint;

    [Header("Prefabs")]
    public GameObject customerPrefab;

    [Header("Movement")]
    public float speed = 2f;

    private GameObject currentCustomer;
    private CharacterMover customerMover;
    private OrderManager orderManager;

    void Start()
    {
        orderManager = FindObjectOfType<OrderManager>();
        if (GameManager.customerGO != null)
        {
            currentCustomer = GameManager.customerGO;
            customerMover = currentCustomer.GetComponent<CharacterMover>();
        }
        else if (GameManager.orderPrepared && !GameManager.orderServed)
        {
            SpawnCustomerAtOrderPoint();
        }
        else if (!GameManager.orderServed)
        {
            SpawnCustomerAtStart();
        }
    }


    void SpawnCustomerAtStart()
    {
        if (currentCustomer != null)
        {
            Destroy(currentCustomer);
        }
        
        currentCustomer = Instantiate(customerPrefab, startPoint.transform.position, Quaternion.identity);
        GameManager.customerGO = currentCustomer;
        customerMover = currentCustomer.GetComponent<CharacterMover>();
        StartCoroutine(EnterCustomer());
    }

    void SpawnCustomerAtOrderPoint()
    {
        if (currentCustomer != null) {
            Destroy(currentCustomer);
        }
        
        currentCustomer = Instantiate(customerPrefab, orderPoint.transform.position, Quaternion.identity);
        GameManager.customerGO = currentCustomer;
        customerMover = currentCustomer.GetComponent<CharacterMover>();
    }

    IEnumerator EnterCustomer()
    {
        if (orderManager != null && orderManager.takeOrderButton != null)
        {
            orderManager.takeOrderButton.gameObject.SetActive(false);
        }

        // Move to order location
        while (currentCustomer != null && 
               Vector3.Distance(currentCustomer.transform.position, orderPoint.transform.position) > 0.1f)
        {
            Vector3 direction = (orderPoint.transform.position - currentCustomer.transform.position).normalized;
            Vector3 localDir = currentCustomer.transform.InverseTransformDirection(direction);
            Vector2 movementInput = new Vector2(localDir.x, localDir.z);
            customerMover.SetInput(movementInput, orderPoint.transform.position, false, false);
            yield return null;
        }
        
        if (currentCustomer != null) {
            customerMover.SetInput(Vector2.zero, orderPoint.transform.position, false, false);
            if (orderManager != null && orderManager.takeOrderButton != null) {
                orderManager.takeOrderButton.gameObject.SetActive(true);
            }
        }
    }

    IEnumerator ExitCustomer() {
        
        currentCustomer = GameManager.customerGO;
        customerMover = currentCustomer.GetComponent<CharacterMover>();

        // Prevent order taking while exiting
        if (orderManager != null && orderManager.takeOrderButton != null) {
            orderManager.takeOrderButton.gameObject.SetActive(false);
        }

        // Move back to start position
        while (currentCustomer != null && 
            Vector3.Distance(currentCustomer.transform.position, startPoint.transform.position) > 0.1f)
        {
            Vector3 direction = (startPoint.transform.position - currentCustomer.transform.position).normalized;
            Vector3 localDir = currentCustomer.transform.InverseTransformDirection(direction);
            Vector2 movementInput = new Vector2(localDir.x, localDir.z);
            customerMover.SetInput(movementInput, startPoint.transform.position, false, false);
            yield return null;
        }
        
        // Destroy customer immediately when they reach start point
        if (currentCustomer != null) {
            Destroy(currentCustomer);
            currentCustomer = null;
            
            // Spawn new customer right after destruction
            if (!GameManager.ShouldEndDay()) {
                SpawnCustomerAtStart();
            }
        }
    }

    public void TriggerCustomerExit() {
        StartCoroutine(ExitCustomer());
    }
}