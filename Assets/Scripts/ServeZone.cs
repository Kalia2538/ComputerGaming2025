/**
Elysa Hines  
Date Created: 03/30/25  
Date Last Updated: 04/16/25 
Summary: Handles logic for snapping a draggable cup into the serve zone. Destroys drag functionality once snapped.
*/

using UnityEngine;

public class ServeZone : MonoBehaviour {
    [Header("Snap Point")]
    public Transform snapPoint;

    void OnTriggerEnter(Collider other) {

         // Helps debug zone collisions
        Debug.Log("Something entered the serve zone: " + other.name);

        if (other.CompareTag("Cup")) {

            // Verifies correct object enters zone
            Debug.Log("Cup entered serve zone!");

            if (snapPoint != null) {
                other.transform.position = snapPoint.position;
                other.transform.rotation = snapPoint.rotation;
            }

            DraggableCup drag = other.GetComponent<DraggableCup>();
            if (drag != null) {
                // Prevents cup from being dragged again after being served
                Destroy(drag); 
            }
        }
    }
}