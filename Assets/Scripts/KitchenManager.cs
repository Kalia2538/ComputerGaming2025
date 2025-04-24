/**
* Author: Hana Ismaiel, Kalia Brown, Elysa Hines
* Date Created: 04/16/2025
* Date Last Updated: 04/16/2025
* Summary: Handles kitchen scene logic and return to cafe transition
*/

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KitchenManager : MonoBehaviour  {
    [Header("UI References")]
    public Button doneButton;

    void Start() {
        doneButton.onClick.AddListener(ReturnToCafe);
    }

    // Transition back to cafe and update score
void ReturnToCafe() {
    // Don't reset order or score here — the serve step will handle that!
    SceneManager.LoadScene("cafe_v2_with_characters");
}

}