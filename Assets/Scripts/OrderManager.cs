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
    public GameObject orderConfirmationEffect;
    public GameObject heartEffect;
    public GameObject badOrderEffect;

    [Header("Buttons")]
    public Button takeOrderButton;
    public Button okButton;
    public Button goToKitchenButton;
    public Button serveButton;

    [Header("Audio")]
    public AudioSource cashRegisterSound;
    public AudioSource buttonClickSound;
    public AudioSource successSound;
    public AudioSource failureSound;

    private string customerDrink;
    private string customerFood;
    private float orderStartTime;

    void Start()  {
        InitializeButtonListeners();
        ResetUIState();
        UpdateScoreDisplay();

        if (GameManager.orderPrepared && !GameManager.orderServed) {
            takeOrderButton.gameObject.SetActive(false);
            serveButton.gameObject.SetActive(true);
        }
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
        if (orderConfirmationEffect != null) {
            orderConfirmationEffect.SetActive(true);
            // Play all particle systems in children
            var particleSystems = orderConfirmationEffect.GetComponentsInChildren<ParticleSystem>();
            foreach (var ps in particleSystems) {
                ps.Play();
            }
        }
        Invoke("HideOrderConfirmationEffects", 1.5f);
    }

    void HideOrderConfirmationEffects()  {
        if (orderConfirmationEffect != null) {
            orderConfirmationEffect.SetActive(false);
        }
    }

    void ShowReactionEffect(GameObject effect, AudioSource sound) {
        effect.SetActive(true);
        if (sound != null) {
            sound.Play();
        };
        var particleSystems = effect.GetComponentsInChildren<ParticleSystem>();
        foreach (var ps in particleSystems) {
            ps.Play();
        }
        Invoke("HideReactionEffect", 1.7f);
    }

    void HideReactionEffect() {
        heartEffect.SetActive(false);
        badOrderEffect.SetActive(false);
        StartNewOrder();
    }

    void GoToKitchen() {
        goToKitchenButton.gameObject.SetActive(false);
        SceneManager.LoadScene("Kitchen");
        GameManager.timeStarted = Time.time;
    }

    void ServeOrder()  {
        serveButton.gameObject.SetActive(false);
        GameManager.orderServed = true;
        GameManager.customersServedToday += 1;
        GameManager.CalculateAndAddScore();
        UpdateScoreDisplay();

        // Show appropriate reaction effect depending on order accuracy
        if (GameManager.perfectOrder) {
            ShowReactionEffect(heartEffect, successSound);
        } else {
            ShowReactionEffect(badOrderEffect, failureSound);
        }
        Debug.Log(GameManager.customersServedToday);

        if (GameManager.ShouldEndDay()) {
            GameManager.StartNewDay();
            SceneManager.LoadScene("DayTransition");
        }
    }

    void UpdateScoreDisplay() {
        scoreText.text = "Score: " + GameManager.totalScore;
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
        GameManager.Reset();
        takeOrderButton.gameObject.SetActive(true);
    }
}
