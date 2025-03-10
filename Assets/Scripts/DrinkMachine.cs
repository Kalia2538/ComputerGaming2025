using UnityEngine;

public class DrinkMachine : MonoBehaviour {
    public GameObject prefab;
    public GameObject spawnPoint;
    private static GameObject drink = null;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject) {
                if (drink == null) {
                    drink = Instantiate(prefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
                } else {
                    Debug.Log("Drink already served.");
                }
            }
        }
    }
}