using UnityEngine;

public class FoodItem : MonoBehaviour {
    public GameObject prefab;
    public GameObject spawnPoint;
    private static GameObject food = null;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0) && food == null) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.gameObject == gameObject) {
                    food = Instantiate(prefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
                }
            }
        } else if (food != null) {
            Debug.Log("Food already served.");
        }
    }
}