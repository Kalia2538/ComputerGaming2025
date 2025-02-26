using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerInteraction : MonoBehaviour
{
    // locations where the customer will move from
    public Vector3 orderPoint;
    public Vector3 endPoint;
    public Vector3 startPoint;

    // customer vars
    public GameObject customer;
    public float speed;

    public GameObject order;
    public Vector3 orderPos;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(OrderProcess());
    }


    IEnumerator EnterScreen()
    {
        customer.transform.position = Vector3.MoveTowards(startPoint,
            orderPoint, speed * Time.deltaTime);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

    }

    IEnumerator TakingOrder()
    {
        Instantiate(order);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
    }

    IEnumerator ExitingScreen()
    {
        customer.transform.position = Vector3.MoveTowards(orderPoint,
            endPoint, speed * Time.deltaTime);
        yield return null;
    }

    IEnumerator OrderProcess()
    {
        Instantiate(customer);
        yield return EnterScreen();
        yield return TakingOrder();
        yield return ExitingScreen();
        Destroy(customer);
    }
}
