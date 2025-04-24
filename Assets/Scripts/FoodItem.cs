/**
* Authors: Hana Ismaiel, Kalia Brown, Elysa Hines
* Date Created: 04/16/2025
* Date Last Updated: 04/24/2025
* Summary: Handles food spawning for bakery item interactions
*/

using UnityEngine;

public class FoodItem : MonoBehaviour {
    [Header("Spawn Settings")]
    public GameObject prefab;
    public GameObject spawnPoint;

    [Header("Food Type")]
    public string foodType = "croissant"; // default, override in inspector

    private static GameObject food = null;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject) {
                if (food == null) {
                    food = Instantiate(prefab, spawnPoint.transform.position, spawnPoint.transform.rotation);

                    // Register the food with the ItemManager
                    if (!string.IsNullOrEmpty(foodType))
                        ItemManager.SetPreparedFood(foodType.ToLower());
                    else
                        Debug.LogWarning("No food type set in FoodItem.cs!");
                } else {
                    Debug.Log("Food already served.");
                }
            }
        }
    }
}
