using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controller;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

/**
    Author: Kalia Brown, Elysa Hines, Hana Ismaiel
    Date Created: 3/1/2025
    Date Last Updated: 4/16/2025
    Summary: Placeholder code to simulate movement of customer in and
        out of the cafe 
 */

public class CustomerInteraction : MonoBehaviour
{
    // locations for ordering
    public GameObject orderPoint;    
    public GameObject spawnPoint;
    public CustomerInteraction Instance;

    public GameObject currCustomer;
    // instantiated prefabs
    private GameObject customer;

    //prefabs
    public GameObject customerPrefab;

    private CharacterMover mover;
    
    public float speed = 3;

    private enum CustomerState
    {
        Empty,
        Entered,
        RecievedOrder,
        Exited
    }
    private static CustomerState customerState = CustomerState.Empty;
    private bool isHandlingState = false;
    private static Vector3 savedPosition;
    private static Quaternion savedRotation;
    private static bool positionIsSaved;

    private void custDebug() {
        Debug.Log("Cutomer state is:");
        Debug.Log(customerState);
    }




    private void Awake()
    {
        custDebug();
        Debug.Log("in awake");
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        if (currCustomer != null) {
            customer = currCustomer;
            mover = customer.GetComponent<CharacterMover>();
            DontDestroyOnLoad(customer);
        } else if (customer == null || customerState == CustomerState.Empty)
        {
            InstantiateCustomer();
        }


        DontDestroyOnLoad(orderPoint);
        DontDestroyOnLoad(spawnPoint); // TODO: make sure this references the right game object (the start point)
        
        // instantiates a customer if none assigned
        

        if (!isHandlingState) {
            StartCoroutine(AfterSceneLoad());
        }

        //HandleState();


    }

    private IEnumerator AfterSceneLoad()
    {
        Debug.Log("in after scene load");
        custDebug();
        yield return null; // wait one frame
        if (!isHandlingState)
            StartCoroutine(HandleState());
    }
    private IEnumerator HandleState() {
        Debug.Log("in handle state");
        custDebug();
        isHandlingState = true;
        switch(customerState)
        {
            case CustomerState.Empty:
                EnterScene();
                custDebug();
                break;
            case CustomerState.Entered:
                savedPosition = customer.transform.position;
                savedRotation = customer.transform.rotation;
                positionIsSaved = true;
                custDebug();

                yield return new WaitUntil(() => SceneManager.GetActiveScene().name != "cafe_v2_with_characters");

                custDebug();
                // Now wait until we return
                yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "cafe_v2_with_characters");
                custDebug();
                if ( positionIsSaved)
                {
                    customer.transform.position = savedPosition;
                    customer.transform.rotation = savedRotation;
                    custDebug();
                    LeaveScene();
                }

                orderPoint = GameObject.Find("OrderPoint");
                spawnPoint = GameObject.Find("SpawnPoint");
                custDebug();
                break;
            case CustomerState.RecievedOrder:
                custDebug();
                LeaveScene();
                break;
            case CustomerState.Exited:
                custDebug();
                InstantiateCustomer();
                break;
        }
        isHandlingState = false;
        yield return null;
    }

    private void InstantiateCustomer() {
        Debug.Log("in instantiate customer");
        if (customer == null)
        {
            customer = Instantiate(customerPrefab, spawnPoint.transform.position, Quaternion.identity);
            
            mover = customer.GetComponent<CharacterMover>();

            DontDestroyOnLoad(customer);

            if (customerState == CustomerState.Entered)
            {
                customer.transform.position = orderPoint.transform.position;
            }
            else
            {
                customer.transform.position = spawnPoint.transform.position;
            }
        }

        //customer = Instantiate(customerPrefab, spawnPoint.transform.position, Quaternion.identity);
        //mover = customer.GetComponent<CharacterMover>();
        customerState = CustomerState.Empty;
    }

    private void EnterScene() {
        Debug.Log("in enter scene");
        //// customer moves towards specified location
        //Move(orderPoint.transform.position);
        //// stops customer movement
        //mover.SetInput(Vector2.zero, mover.transform.position, false, false);
        //customerState = CustomerState.Entered;

        if (Vector3.Distance(customer.transform.position, orderPoint.transform.position) > 0.1f)
        {
            Move(orderPoint.transform.position);
        }
        else
        {
            mover.SetInput(Vector2.zero, mover.transform.position, false, false);
        }

        customerState = CustomerState.Entered;
    }

    private void LeaveScene() {
        Debug.Log("in leave scene");
        Move(spawnPoint.transform.position);
        Destroy(customer);
        customerState = CustomerState.Exited;
    }


    private void Move(Vector3 target)
    {
        Debug.Log("in move");
        StartCoroutine(MoveCoroutine(target));
    }

    private IEnumerator MoveCoroutine(Vector3 target)
    {
        Debug.Log("in move coroutine");
        while (Vector3.Distance(customer.transform.position, target) > 0.1f)
        {
            Vector3 direction = (target - customer.transform.position).normalized;
            Vector3 localDirection = customer.transform.InverseTransformDirection(direction);
            Vector2 movementInput = new Vector2(localDirection.x,localDirection.z);
            mover.SetInput(movementInput, target, false, false);
            yield return null;

        }
    }

    private void Update() { 

    }

}
