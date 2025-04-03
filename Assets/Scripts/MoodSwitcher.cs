using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class MoodSwitcher : MonoBehaviour {
    public PostProcessVolume volume;
    public PostProcessProfile[] moods;

    private int currentMood = 0;

    void Start() {
        if (volume != null && moods.Length > 0) {
            volume.profile = moods[currentMood];
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.M)) {
            currentMood = (currentMood + 1) % moods.Length;
            volume.profile = moods[currentMood];
            Debug.Log("Switched to mood: " + moods[currentMood].name);
        }
    }
}
