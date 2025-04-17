/**
Date Created: 04/02/25  
Date Last Updated: 04/16/25 
Summary: Cycles through a list of PostProcessing profiles when the user presses the "M" key.
*/

using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class MoodSwitcher : MonoBehaviour {
    [Header("Mood Settings")]
    public PostProcessVolume volume;
    public PostProcessProfile[] moods;

    private int currentMood = 0;

    void Start() {
        if (volume != null && moods.Length > 0) {
            // Ensures a mood is applied on start
            volume.profile = moods[currentMood]; 
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.M)) {
            currentMood = (currentMood + 1) % moods.Length;
            volume.profile = moods[currentMood];
            // Tracks profile switching for debugging
            Debug.Log("Switched to mood: " + moods[currentMood].name); 
        }
    }
}
