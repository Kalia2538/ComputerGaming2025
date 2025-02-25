using UnityEngine;

// Class to spawn a cup when the player clicks on it
public class CupSpawner : MonoBehaviour {
    public GameObject prefab;
    public GameObject spawnPoint;
    private static bool hasSpawned = false; // Disable spawning when a cup has been spawned


    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !hasSpawned) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.gameObject == gameObject) {
                    GameObject clone = Instantiate(prefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
                    hasSpawned = true;
                }
            }
        }
    }
}