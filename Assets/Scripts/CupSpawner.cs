/**
* Authors: Hana Ismaiel, Kalia Brown, Elysa Hines
* Date Created: 04/16/2025
* Date Last Updated: 04/16/2025
* Summary: Manages cup spawning mechanics with click interaction
*/

using UnityEngine;

public class CupSpawner : MonoBehaviour {
    public GameObject prefab;
    public GameObject spawnPoint;
    public GameObject dispenseButtons;
    private static GameObject spawnedCup = null; // Track the spawned cup

    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0) && spawnedCup == null) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                // Instantiate the cup
                if (hit.collider.gameObject == gameObject) {
                    spawnedCup = Instantiate(prefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
                }
            }
        }
    }

    public static GameObject GetSpawnedCup() {
        return spawnedCup;
    }
}

