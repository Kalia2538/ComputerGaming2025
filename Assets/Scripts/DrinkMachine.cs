/**
* Authors: Hana Ismaiel, Kalia Brown, Elysa Hines
* Date Created: 04/16/2025
* Date Last Updated: 04/16/2025
* Summary: Handles drink spawning for espresso machine interactions
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
                    // Instantiates new drink at specified spawn point
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
    public static GameObject GetSpawnedCup() {
        return spawnedDrink;
    }
}