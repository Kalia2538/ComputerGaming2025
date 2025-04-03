using UnityEngine;

public class DraggableCup : MonoBehaviour {
    private Vector3 offset;
    private bool isDragging = false;
    private Camera cam;

    public Material glowMaterial;
    private Material originalMaterial;
    private Renderer cupRenderer;

    private int clickableLayerMask;

    void Start() {
        cam = Camera.main;
        clickableLayerMask = ~LayerMask.GetMask("NonClickable");

        cupRenderer = GetComponent<Renderer>();
        originalMaterial = cupRenderer.material;
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

    void OnMouseEnter() {
    if (glowMaterial != null && cupRenderer != null) {
        cupRenderer.material = glowMaterial;
    }
}

void OnMouseExit() {
    if (originalMaterial != null && cupRenderer != null) {
        cupRenderer.material = originalMaterial;
    }
}


    Vector3 GetMouseWorldPosition() {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = cam.WorldToScreenPoint(transform.position).z;
        return cam.ScreenToWorldPoint(mousePoint);
    }
}
