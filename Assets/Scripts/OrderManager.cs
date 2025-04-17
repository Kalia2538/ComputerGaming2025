/**
* Authors: Hana Ismaiel, Kalia Brown, Elysa Hines
* Date Created: 04/16/2025
* Date Last Updated: 04/16/2025
* Summary: Manages cafe order flow and customer interactions
*/

using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class OrderManager : MonoBehaviour  {
    [Header("UI Elements")]
    public TextMeshProUGUI orderText;
    public TextMeshProUGUI scoreText;
    public GameObject customerOrder;
    public GameObject sparkleEffect;

    [Header("Buttons")]
    public Button takeOrderButton;
    public Button okButton;
    public Button goToKitchenButton;
    public Button serveButton;

    [Header("Audio")]
    public AudioSource cashRegisterSound;
    public AudioSource buttonClickSound;

    private string customerDrink;
    private string customerFood;
    private float orderStartTime;

    void Start()  {
        InitializeButtonListeners();
        ResetUIState();
        scoreText.text = "Score: " + GameManager.totalScore;
    }

    void InitializeButtonListeners()  {
        takeOrderButton.onClick.AddListener(() => { PlayButtonSound(); ShowOrder(); });
        okButton.onClick.AddListener(() => { PlayButtonSound(); ConfirmOrder(); });
        goToKitchenButton.onClick.AddListener(() => { PlayButtonSound(); GoToKitchen(); });
        serveButton.onClick.AddListener(() => { PlayButtonSound(); ServeOrder(); });
    }

    void ResetUIState() {
        takeOrderButton.gameObject.SetActive(true);
        okButton.gameObject.SetActive(false);
        goToKitchenButton.gameObject.SetActive(false);
        serveButton.gameObject.SetActive(false);
    }

    void PlayButtonSound() {
        if (buttonClickSound != null) {
            buttonClickSound.Play();
        }
    }

    void ShowOrder()  {
        GenerateNewOrder();
        UpdateOrderDisplay();
        StoreOrderDetails();
    }

    void GenerateNewOrder() {
        customerDrink = GenerateDrink();
        customerFood = GenerateFood();
        orderStartTime = Time.time;
    }

    void UpdateOrderDisplay() {
        orderText.text = $"Can I get a {customerDrink} and a {customerFood}?";
        customerOrder.SetActive(true);
        takeOrderButton.gameObject.SetActive(false);
        okButton.gameObject.SetActive(true);
    }

    void StoreOrderDetails() {
        GameManager.expectedDrink = customerDrink;
        GameManager.expectedFood = customerFood;
    }

    void ConfirmOrder()  {
        TransitionToKitchenReadyState();
        PlayOrderConfirmationEffects();
    }

    void TransitionToKitchenReadyState() {
        customerOrder.SetActive(false);
        okButton.gameObject.SetActive(false);
        goToKitchenButton.gameObject.SetActive(true);
    }

    void PlayOrderConfirmationEffects() {
        if (cashRegisterSound != null) {
            cashRegisterSound.Play();
        }
        sparkleEffect.SetActive(true);
        sparkleEffect.GetComponent<ParticleSystem>().Play();
        Invoke("HideSparkleEffect", 1.5f);
    }

    void GoToKitchen() {
        goToKitchenButton.gameObject.SetActive(false);
        SceneManager.LoadScene("Kitchen");
        GameManager.timeStarted = Time.time;
    }

    void ServeOrder()  {
        UpdateScoreDisplay();
        Invoke("StartNewOrder", 2f);
    }

    void UpdateScoreDisplay() {
        scoreText.text = "Score: " + GameManager.totalScore;
    }

    void HideSparkleEffect()  {
        sparkleEffect.SetActive(false);
    }

    int CalculateScore(bool correctDrink, bool correctFood, float timeTaken)  {
        int score = (correctDrink ? 50 : 0) + (correctFood ? 50 : 0);
        int timeBonus = Mathf.Clamp(150 - Mathf.FloorToInt(timeTaken * 10), 0, 150);
        return score + timeBonus;
    }

    string GenerateDrink()  {
        string[] drinks = { "cup of coffee", "cup of tea", "shot of espresso" };
        return drinks[Random.Range(0, drinks.Length)];
    }

    string GenerateFood()  {
        string[] foods = { "croissant", "cupcake", "donut", "macaron" };
        return foods[Random.Range(0, foods.Length)];
    }

    void StartNewOrder()  {
        GameManager.orderPrepared = false;
        takeOrderButton.gameObject.SetActive(true);
        serveButton.gameObject.SetActive(false);
    }
}