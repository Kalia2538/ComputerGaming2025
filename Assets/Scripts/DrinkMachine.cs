using UnityEngine;

public class DrinkMachine : MonoBehaviour {
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
                    Debug.Log("Drink spawned.");
                } else {
                    Debug.Log("Drink already served.");
                }
            }
        }
    }

        public static GameObject GetSpawnedCup() {
        return spawnedDrink;
    }
}