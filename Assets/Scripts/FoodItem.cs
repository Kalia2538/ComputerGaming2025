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
                    food = Instantiate(prefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
                } else {
                    Debug.Log("Food already served.");
                }
            }
        }
    }
}
