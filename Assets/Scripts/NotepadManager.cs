/**
* Authors: Hana Ismaiel, Kalia Brown, Elysa Hines
* Date Created: 04/16/2025
* Date Last Updated: 04/16/2025
* Summary: Manages persistence of the notepad UI element across scenes
*/

using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NotepadManager : MonoBehaviour {
    [Header("Prefab References")]
    public GameObject notepadPrefab;

    private static GameObject persistentNotepad;

    void Awake() {
        // Ensure only one notepad exists
        if (persistentNotepad == null) {
            persistentNotepad = Instantiate(notepadPrefab);
            DontDestroyOnLoad(persistentNotepad);
        } else {
            Destroy(gameObject); // Prevent duplicate notepads
        }
    }
}