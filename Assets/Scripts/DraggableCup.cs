/**
Author: Elysa Hines  
Date Created: 03/30/25  
Date Last Updated: 04/16/25
Summary: Allows the player to drag and move the cup GameObject using the mouse, with proper offset handling and layer filtering.
*/

using UnityEngine;

public class DraggableCup : MonoBehaviour {
    private Vector3 offset;
    private bool isDragging = false;
    private Camera cam;

    private int clickableLayerMask;

    void Start() {
        cam = Camera.main;
        // Ignore objects on the 'NonClickable' layer, such as the espresso machine to 
        // prevent overlap in clicks
        clickableLayerMask = ~LayerMask.GetMask("NonClickable"); 
    }

    void OnMouseDown() {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, clickableLayerMask)) {
            if (hit.collider.gameObject == gameObject) {
                isDragging = true;
                offset = transform.position - GetMouseWorldPosition();
                 // Confirm player has clicked and started dragging
                Debug.Log("Started dragging cup!");
            }
        }
    }

    void OnMouseDrag() {
        if (isDragging) {
            transform.position = GetMouseWorldPosition() + offset;
        }
    }

    void OnMouseUp() {
        isDragging = false;
    }

    Vector3 GetMouseWorldPosition() {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = cam.WorldToScreenPoint(transform.position).z;
        return cam.ScreenToWorldPoint(mousePoint);
    }
}
