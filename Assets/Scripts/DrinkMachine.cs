using UnityEngine;

public class DrinkMachine : MonoBehaviour {
    public GameObject prefab;
    public GameObject spawnPoint;
    private static GameObject drink = null;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0) && drink == null) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.gameObject == gameObject) {
                    drink = Instantiate(prefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
                }
            }
        } else if (drink != null) {
            Debug.Log("Drink already served.");
        }
    }
}