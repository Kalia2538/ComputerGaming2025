using UnityEngine;
using UnityEngine.UI;

public class CameraScrollBar : MonoBehaviour {
    public Camera targetCamera;
    public Slider cameraSlider; 
    public float minX = -2.06f;
    public float maxX = 1.76f;
    
    public float keyboardSpeed = 1f; 

        void Start() {
        if (cameraSlider != null) {
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
        Debug.Log("Slider value: " + value);

        if (targetCamera == null) return;

        float x = Mathf.Lerp(minX, maxX, value);
        Vector3 camPos = targetCamera.transform.position;
        camPos.x = x;
        targetCamera.transform.position = camPos;
    }
}
