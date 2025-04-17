/**
* Authors: Hana Ismaiel, Kalia Brown, Elysa Hines
* Date Created: 04/16/2025
* Date Last Updated: 04/16/2025
* Summary: Ensures single EventSystem instance persists across scenes
*/

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PersistentEventSystem : MonoBehaviour {
    private static PersistentEventSystem instance;

    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        } else {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        CleanDuplicateEventSystems();
    }

    // When returning to the cafe, the EventSystem may be duplicated, so we need to destroy all existing event systems
    void CleanDuplicateEventSystems() {
        EventSystem[] allEventSystems = FindObjectsOfType<EventSystem>();
        foreach (var es in allEventSystems) {
            if (es.gameObject != this.gameObject) {
                Destroy(es.gameObject);
            }
        }
    }

    void OnDestroy() {
        if (instance == this) {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}