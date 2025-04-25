/**
* Authors: Hana Ismaiel, Kalia Brown, Elysa Hines
* Date Created: 04/16/2025
* Date Last Updated: 04/24/2025
* Summary: Manages persistence of the notepad UI element across scenes
*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class NotepadManager : MonoBehaviour {
    public GameObject notepadPrefab;
    private static GameObject persistentNotepad;
    private static bool initialized = false;

    void Awake() {
        // Ensure this runs only once
        if (initialized)  {
            Destroy(gameObject);
            return;
        }

        initialized = true;
        DontDestroyOnLoad(gameObject);
        
        // Create notepad if it doesn't exist
        if (persistentNotepad == null) {
            persistentNotepad = Instantiate(notepadPrefab);
            DontDestroyOnLoad(persistentNotepad);
        }

        // Update visibility depending on the scene
        UpdateNotepadVisibility();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        UpdateNotepadVisibility();
    }

    void UpdateNotepadVisibility() {
        if (persistentNotepad == null) return;
        
        string sceneName = SceneManager.GetActiveScene().name;
        // Don't show in DayTransition scene
        bool showInScene = sceneName == "cafe_v2_with_characters" || sceneName == "Kitchen";
        
        if (persistentNotepad.activeSelf != showInScene) {
            persistentNotepad.SetActive(showInScene);
        }
    }

    void OnDestroy() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}