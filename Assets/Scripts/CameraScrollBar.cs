/**
Elysa Hines  
Date Created: 04/04/25  
Date Last Updated: 04/16/25 
Summary: Controls horizontal scrolling of the camera via a disabled slider that can be adjusted with arrow keys.
*/

using UnityEngine;
using UnityEngine.UI;

public class CameraScrollBar : MonoBehaviour {
    [Header("Camera and UI")]
    public Camera targetCamera;
    public Slider cameraSlider; 

    [Header("Scroll Range")]
    public float minX = -2.06f;
    public float maxX = 1.76f;

    [Header("Keyboard Control")]
    public float keyboardSpeed = 1f;

    void Start() {
        if (cameraSlider != null) {
             // Prevent manual dragging, this is keyboard-controlled so turns off teh clickable componenet
            cameraSlider.interactable = false;
        }
    }

    void Update() {
        if (cameraSlider == null || targetCamera == null)
            return;

        float delta = 0f;
        if (Input.GetKey(KeyCode.LeftArrow)) {
            delta = -keyboardSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow)) {
            delta = keyboardSpeed * Time.deltaTime;
        }

        if (delta != 0f) {
            cameraSlider.value = Mathf.Clamp01(cameraSlider.value + delta);
            OnScroll(cameraSlider.value);
        }
    }

    public void OnScroll(float value) {
        // Helpful for tuning min/max range in-editor
        Debug.Log("Slider value: " + value);

        if (targetCamera == null) return;

        float x = Mathf.Lerp(minX, maxX, value);
        Vector3 camPos = targetCamera.transform.position;
        camPos.x = x;
        targetCamera.transform.position = camPos;
    }
}