using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Controller;

public class CustomerInteraction : MonoBehaviour
{
    [Header("Scene Points")]
    public GameObject orderPoint;
    public GameObject startPoint;
    public GameObject orderLoc;

    [Header("Prefabs")]
    public GameObject customerPrefab;
    public GameObject order;

    public float speed = 2f;

    private static GameObject customer;
    private static CustomerInteraction instance;

    private GameObject orderObj;
    private Rigidbody custRigidBody;
    private CharacterMover mover;

    private bool inRoutine = false;

    void Awake()
    {
        // Ensure only one manager exists
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneLoaded += OnSceneReload;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneReload;
    }

    void OnSceneReload(Scene scene, LoadSceneMode mode)
    {
        if (customer != null)
        {
            customer.SetActive(true);

            // Reassign references after scene reload
            if (custRigidBody == null) custRigidBody = customer.GetComponent<Rigidbody>();
            if (mover == null) mover = customer.GetComponent<CharacterMover>();

            // Restart loop if needed
            if (!inRoutine)
                StartCoroutine(OrderProcess(mover));
        }
    }

    void Start()
    {
        if (customer == null)
        {
            customer = Instantiate(customerPrefab, startPoint.transform.position, Quaternion.identity);
            DontDestroyOnLoad(customer);
        }

        custRigidBody = customer.GetComponent<Rigidbody>();
        mover = customer.GetComponent<CharacterMover>();
        StartCoroutine(OrderProcess(mover));
    }

    IEnumerator OrderProcess(CharacterMover mover)
    {
        if (inRoutine) yield break;
        inRoutine = true;

        yield return EnterScreen(mover);
        yield return TakingOrder(mover);
        yield return new WaitUntil(() => GameManager.orderServed);
        yield return ExitingScreen(mover);

        GameManager.Reset();
        customer.transform.position = startPoint.transform.position;

        inRoutine = false;
        StartCoroutine(OrderProcess(mover));
    }

    IEnumerator EnterScreen(CharacterMover mover)
    {
        while (Vector3.Distance(customer.transform.position, orderPoint.transform.position) > 0.1f)
        {
            Vector3 direction = (orderPoint.transform.position - customer.transform.position).normalized;
            Vector3 localDir = customer.transform.InverseTransformDirection(direction);
            Vector2 movementInput = new Vector2(localDir.x, localDir.z);
            mover.SetInput(movementInput, orderPoint.transform.position, false, false);
            yield return null;
        }

        mover.SetInput(Vector2.zero, customer.transform.position, false, false);
    }

    IEnumerator TakingOrder(CharacterMover mover)
    {
        orderObj = Instantiate(order, orderLoc.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
    }

    IEnumerator ExitingScreen(CharacterMover mover)
    {
        if (orderObj != null)
            Destroy(orderObj);

        while (Vector3.Distance(customer.transform.position, startPoint.transform.position) > 0.1f)
        {
            Vector3 direction = (startPoint.transform.position - customer.transform.position).normalized;
            Vector3 localDir = customer.transform.InverseTransformDirection(direction);
            Vector2 movementInput = new Vector2(localDir.x, localDir.z);
            mover.SetInput(movementInput, startPoint.transform.position, false, false);
            yield return null;
        }

        while (Vector3.Distance(customer.transform.position, startPoint.transform.position) > 0.1f)
        {
            Vector3 direction = (startPoint.transform.position - customer.transform.position).normalized;
            custRigidBody.velocity = direction * speed;
            yield return null;
        }

        custRigidBody.velocity = Vector3.zero;
    }
}
