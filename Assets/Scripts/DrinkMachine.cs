/**
hana Ismaiel and Elysa Hines  
Date Created: 03/10/25  
Date Last Updated: 04/16/25 
Summary: Spawns a drink (cup) at the machine's designated spawn point when clicked. Prevents multiple drinks from being spawned at once.
*/

using UnityEngine;

public class DrinkMachine : MonoBehaviour {
    [Header("Spawn Settings")]
    public GameObject cupPrefab;
    public Transform cupSpawnPoint; 

    private static GameObject spawnedDrink = null;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject) {
                if (spawnedDrink == null) {
                    spawnedDrink = Instantiate(cupPrefab, cupSpawnPoint.transform.position, cupSpawnPoint.transform.rotation);
                    // Confirms new drink was successfully instantiated
                    Debug.Log("Drink spawned.");
                } else {
                    // Prevents duplicate spawns and alerts dev
                    Debug.Log("Drink already served."); 
                }
            }
        }
    }

    public static GameObject GetSpawnedCup() {
        return spawnedDrink;
    }
}