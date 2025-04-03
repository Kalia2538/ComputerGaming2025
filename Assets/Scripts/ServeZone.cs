using UnityEngine;

public class ServeZone : MonoBehaviour {
    public Transform snapPoint;

    void OnTriggerEnter(Collider other) {
     Debug.Log("Something entered the serve zone: " + other.name);
        if (other.CompareTag("Cup")) {
            Debug.Log("Cup entered serve zone!");

            if (snapPoint != null) {
                other.transform.position = snapPoint.position;
                other.transform.rotation = snapPoint.rotation;
            }

            DraggableCup drag = other.GetComponent<DraggableCup>();
            if (drag != null) {
                Destroy(drag);
            }
        }
    }
}
