///**
//* Authors: Hana Ismaiel, Kalia Brown, Elysa Hines
//* Date Created: 05/01/2025
//* Date Last Updated: 05/01/2025
//* Summary: Manages cafe order flow and customer interactions
//*/

//using System.Collections;
//using System.Collections.Generic;
//using Controller;
//using UnityEngine;



//public class CustomerManager : MonoBehaviour
//{
//    public static GameObject orderPoint;
//    public static GameObject spawnPoint;

    
//    public static GameObject customerPrefab;
//    private static GameObject customer;
//    private static CharacterMover mover;
    
//    private float speed = 3; //TODO: adjust this

//    private enum CustomerState { 
//        Empty,
//        Entered,
//        Ordered,
//        RecievedOrder,
//        Exited
//    }
//    CustomerState currState = CustomerState.Empty;

//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    private void Awake()
//    {
//        if (currState)
//        customer = Instantiate(customerPrefab, spawnPoint.transform.position, Quaternion.identity);
//        DontDestroyOnLoad(customer);
//        CharacterMover mover = customer.GetComponent<CharacterMover>();
//    }
    


//    // Update is called once per frame
//    void Update()
//    {
        
//    }
//}
