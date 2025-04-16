using UnityEngine;

public class DraggableCup : MonoBehaviour {
    private Vector3 offset;
    private bool isDragging = false;
    private Camera cam;

    private int clickableLayerMask;

    void Start() {
        cam = Camera.main;
        clickableLayerMask = ~LayerMask.GetMask("NonClickable");
    }


    void OnMouseDown() {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, clickableLayerMask)) {
            if (hit.collider.gameObject == gameObject) {
                isDragging = true;
                offset = transform.position - GetMouseWorldPosition();
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
