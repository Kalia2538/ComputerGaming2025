using System.Collections;
using System.Collections.Generic;
using Controller;
using UnityEngine;
using UnityEngine.AI;

public class NewCustomerSpawning : MonoBehaviour
{
    public GameObject customerPrefab;
    public Transform spawnLoc;
    public Transform counterLoc;
    public float spawnDelay = 5f;
    public float exitDelay = 3f;





    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnCustomer), 1f, spawnDelay);
    }

    void SpawnCustomer() {
        GameObject customer = Instantiate(customerPrefab, spawnLoc.position, Quaternion.identity);
        CharacterMover mover = customer.GetComponent<CharacterMover>();

        if (mover != null && counterLoc != null)
        {
            StartCoroutine(CustomerMovement(customer, mover));
        }
    }

    IEnumerator CustomerMovement(GameObject customer, CharacterMover mover) { 
        Vector3 directionToCounter = (counterLoc.position - customer.transform.position).normalized;
        Vector2 movementInput = new Vector2(directionToCounter.x, directionToCounter.z);

        mover.SetInput(movementInput, counterLoc.position, false, false  ); 
        float distToCounter = Vector3.Distance(customer.transform.position, counterLoc.position);

        while (distToCounter > 0.1f) {
            distToCounter = Vector3.Distance(customer.transform.position, counterLoc.position);
            yield return null;
        }
        yield return new WaitForSeconds(exitDelay);

        Vector3 directionToSpawnLoc = (spawnLoc.position - customer.transform.position).normalized;
        movementInput = new Vector2 (directionToSpawnLoc.x, directionToSpawnLoc.z);
        mover.SetInput(movementInput, spawnLoc.position, false, false );

        float distToSpawnLoc = Vector3.Distance(customer.transform.position, spawnLoc.position);

        while (distToCounter > 0.1f)
        {
            distToSpawnLoc = Vector3.Distance(customer.transform.position, spawnLoc.position);
            yield return null;
        }
        Destroy(customer);

        SpawnCustomer();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
