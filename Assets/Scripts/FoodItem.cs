/**
* Authors: Hana Ismaiel, Kalia Brown, Elysa Hines
* Date Created: 04/16/2025
* Date Last Updated: 04/16/2025
* Summary: Handles food spawning for bakery item interactions
*/

using UnityEngine;

public class FoodItem : MonoBehaviour {
    public GameObject prefab;
    public GameObject spawnPoint;
    private static GameObject food = null;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject) {
                if (food == null) {
                    // Instantiates new food at specified spawn point
                    food = Instantiate(prefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
                } else {
                    Debug.Log("Food already served.");
                }
            }
        }
    }
}
