using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

// class to manage the UI in the cafe scene, taking and serving customer orders
public class OrderManager : MonoBehaviour {
    public TextMeshProUGUI orderText;
    public GameObject customerOrder;
    public Button takeOrderButton;
    public Button okButton;
    public Button goToKitchenButton;
    public Button serveButton;
    public TextMeshProUGUI scoreText;
    public GameObject sparkleEffect;

    private string customerDrink;
    private string customerFood;
    private float orderStartTime;
    private bool orderActive = false;

    void Start() {
        takeOrderButton.onClick.AddListener(ShowOrder);
        okButton.onClick.AddListener(ConfirmOrder);
        goToKitchenButton.onClick.AddListener(GoToKitchen);
        serveButton.onClick.AddListener(ServeOrder);
        
        takeOrderButton.gameObject.SetActive(true);
        okButton.gameObject.SetActive(false);
        goToKitchenButton.gameObject.SetActive(false);
        serveButton.gameObject.SetActive(false);
    }

    // display the customer's order
    void ShowOrder() {
        customerDrink = GenerateDrink();
        customerFood = GenerateFood();
        orderText.text = "Can I get a " + customerDrink + " and a " + customerFood + "? :D";

        customerOrder.SetActive(true);
        takeOrderButton.gameObject.SetActive(false);
        okButton.gameObject.SetActive(true);

        orderStartTime = Time.time;
        orderActive = true;

        // store the expected drink and food based on customer's order
        GameManager.expectedDrink = customerDrink;
        GameManager.expectedFood = customerFood;
    }

    void ConfirmOrder() {
        customerOrder.SetActive(false);
        okButton.gameObject.SetActive(false);
        goToKitchenButton.gameObject.SetActive(true);

        // play sparkle after confirming order
        sparkleEffect.SetActive(true);
        sparkleEffect.GetComponent<ParticleSystem>().Play();
        Invoke("HideSparkleEffect", 1.5f); // stop sparkle after a delay
    }

    void GoToKitchen() {
        goToKitchenButton.gameObject.SetActive(false);
        SceneManager.LoadScene("Kitchen");
        GameManager.timeStarted = Time.time;
    }

    void ServeOrder() {
        if (!GameManager.orderPrepared) {
            return;
        }

        int scoreChange = 0;
        if (GameManager.servedDrink == null || GameManager.servedFood == null) {
            scoreChange -= 100;
        } else {
            bool correctDrink = GameManager.servedDrink.ToLower() == GameManager.expectedDrink.ToLower();
            bool correctFood = GameManager.servedFood.ToLower() == GameManager.expectedFood.ToLower();
            float timeTaken = GameManager.timeTaken;
            scoreChange = CalculateScore(correctDrink, correctFood, timeTaken);
        }

        GameManager.UpdateScore(scoreChange);
        scoreText.text = "Score: " + GameManager.totalScore;
        
        Invoke("StartNewOrder", 2f);
    }

    void HideSparkleEffect() {
        sparkleEffect.SetActive(false);
    }

    // calculate the points to add to the player score
    int CalculateScore(bool correctDrink, bool correctFood, float timeTaken) {
        int score = 0;
        if (correctDrink) {
            score += 50;
        }
        if (correctFood) {
            score += 50;
        }
        int timeBonus = Mathf.Clamp(150 - Mathf.FloorToInt(timeTaken * 10), 0, 150); // bonus for taking a shorter time
        return score + timeBonus;
    }

    // randomly generate a drink
    string GenerateDrink() {
        string[] drinks = { "cup of coffee", "cup of tea", "shot of espresso" };
        return drinks[Random.Range(0, drinks.Length)];
    }

    // randomly generate a food 
    string GenerateFood() {
        string[] foods = { "croissant", "cupcake", "donut", "macaron" };
        return foods[Random.Range(0, foods.Length)];
    }

    // restart the game loop to start a new order
    void StartNewOrder() {
        orderActive = false;
        GameManager.orderPrepared = false;
        takeOrderButton.gameObject.SetActive(true);
        serveButton.gameObject.SetActive(false);
    }
}
