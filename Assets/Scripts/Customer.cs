using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    private enum CustomerState
    {
        Empty,
        Entered,
        Ordered,
        RecievedOrder,
        Exited
    }
    private CustomerState customerState = CustomerState.Empty;
    public struct CustomerInfo { 
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if (customerState == CustomerState.Empty)
        {

        }
    }
}
