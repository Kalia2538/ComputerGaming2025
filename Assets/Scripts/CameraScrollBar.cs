using UnityEngine;
using UnityEngine.UI;

public class CameraScrollBar : MonoBehaviour {
    public Camera targetCamera;
    public float minX = -2.06f;
    public float maxX = 1.76f;

    public void OnScroll(float value) {
        Debug.Log("Slider value: " + value); // For debugging

        if (targetCamera == null) return;

        float x = Mathf.Lerp(minX, maxX, value);
        Vector3 camPos = targetCamera.transform.position;
        camPos.x = x;
        targetCamera.transform.position = camPos;
    }
}
