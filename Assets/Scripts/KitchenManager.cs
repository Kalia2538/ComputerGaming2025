using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KitchenManager : MonoBehaviour {
    public Button doneButton;

    void Start() {
        doneButton.onClick.AddListener(DoneWithOrder);
        doneButton.gameObject.SetActive(true);
    }

    void DoneWithOrder() {
        SceneManager.LoadScene("cafe_v2_with_characters");
    }
}
