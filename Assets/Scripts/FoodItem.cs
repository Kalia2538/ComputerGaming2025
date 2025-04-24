/**
* Authors: Hana Ismaiel, Kalia Brown, Elysa Hines
* Date Created: 04/16/2025
* Date Last Updated: 04/23/2025
* Summary: Handles food spawning for bakery item interactions
*/

using UnityEngine;

public class FoodItem : MonoBehaviour {
    public GameObject prefab;
    public GameObject spawnPoint;
    private static GameObject spawnedFood = null;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject) {
                if (spawnedFood == null) {
                    // Instantiates new food at specified spawn point
                    spawnedFood = Instantiate(prefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
                } else {
                    Debug.Log("Food already served.");
                }
            }
        }
    }

    public static string GetFoodName() {
        if (spawnedFood == null) return "none";
        
        string prefabName = spawnedFood.name.ToLower();
        
        if (prefabName.Contains("croissant")) return "croissant";
        if (prefabName.Contains("cupcake")) return "cupcake";
        if (prefabName.Contains("donut")) return "donut";
        if (prefabName.Contains("macaron")) return "macaron";
        
        return "none";
    }

    public static void ClearFood() {
        if (spawnedFood != null) {
            Destroy(spawnedFood);
            spawnedFood = null;
        }
    }
}
