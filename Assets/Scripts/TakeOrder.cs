using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TakeOrder : MonoBehaviour {
    public TextMeshProUGUI orderText;
    public Button takeOrderButton;
    public Button okButton;
    public GameObject orderInput; 
    public GameObject sparkleEffect;

    private string drink;
    private string food;

    void Start() {
        takeOrderButton.onClick.AddListener(ShowOrder);
        okButton.onClick.AddListener(ConfirmOrder);
        okButton.gameObject.SetActive(false);
        orderText.gameObject.SetActive(false);
        orderInput.SetActive(false);
        sparkleEffect.SetActive(false);
    }

    void ShowOrder() {
        drink = GenerateDrink();
        food = GenerateFood();
        orderText.text = "Can I get a " + drink + " and a " + food + "?";
        orderText.gameObject.SetActive(true);

        takeOrderButton.gameObject.SetActive(false);
        okButton.gameObject.SetActive(true);
        orderInput.SetActive(true);
    }

    void ConfirmOrder() {
        sparkleEffect.SetActive(true);
        sparkleEffect.GetComponent<ParticleSystem>().Play();
        orderText.gameObject.SetActive(false);
        orderInput.SetActive(false);
        okButton.gameObject.SetActive(false);
        Invoke("HideSparkleEffect", 1.5f);
    }

    void HideSparkleEffect() {
        sparkleEffect.SetActive(false);
    }

    string GenerateDrink() {
        string[] drinks = { "cup of coffee", "cup of tea", "shot of espresso" };
        return drinks[Random.Range(0, drinks.Length)];
    }

    string GenerateFood() {
        string[] foods = { "croissant", "cupcake", "donut", "macaron" };
        return foods[Random.Range(0, foods.Length)];
    }
}
