/**
* Author: Hana Ismaiel, Kalia Brown, Elysa Hines
* Date Created: 04/23/2025
* Date Last Updated: 04/23/2025
* Summary: Handles scene transition for each new day
*/

using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class DayTransition : MonoBehaviour {
    public TextMeshProUGUI dayText;
    public float displayTime = 2f; // How long to show the screen
    public string nextSceneName = "cafe_v2_with_characters";

    void Start() {
        dayText.text = $"Day {GameManager.currentDay}";
        // Start the transition
        StartCoroutine(TransitionToNextScene());
    }

    IEnumerator TransitionToNextScene() {
        // Wait for the display time
        yield return new WaitForSeconds(displayTime);
        SceneManager.LoadScene(nextSceneName);
    }
}