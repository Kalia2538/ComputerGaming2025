using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoToKitchen : MonoBehaviour {
    public Button goToKitchenButton;

    void Start() {
        goToKitchenButton.onClick.AddListener(SwitchToKitchenScene);
    }

    void SwitchToKitchenScene() {
        SceneManager.LoadScene("Kitchen");
    }
}
