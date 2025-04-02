using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OKButtonScript : MonoBehaviour {
    public TextMeshProUGUI orderText;
    public Button okButton;
    public Button goToKitchenButton;

    void Start() {
        okButton.onClick.AddListener(HideOrderAndShowKitchenButton);
        goToKitchenButton.gameObject.SetActive(false);
    }

    void HideOrderAndShowKitchenButton() {
        orderText.gameObject.SetActive(false);
        okButton.gameObject.SetActive(false);
        goToKitchenButton.gameObject.SetActive(true);
    }
}