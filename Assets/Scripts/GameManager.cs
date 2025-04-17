/**
* Authors: Hana Ismaiel, Kalia Brown, Elysa Hines
* Date Created: 04/16/2025
* Date Last Updated: 04/16/2025
* Summary: Central game state manager for tracking orders and scores
*/

using UnityEngine;

public class GameManager : MonoBehaviour  {
    public static GameManager Instance;

    [Header("Order Tracking")]
    public static string expectedDrink;
    public static string expectedFood;
    public static string servedDrink;
    public static string servedFood;

    [Header("Timing")]
    public static float timeStarted;
    public static float timeTaken;

    [Header("Game State")]
    public static bool orderPrepared = false;
    public static int totalScore = 0;

    void Awake()  {
        if (Instance == null)  {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else  {
            Destroy(gameObject);
        }
    }
    
    // Records completed order details and preparation time
    public static void OrderCompleted(string drink, string food) {
        servedDrink = drink;
        servedFood = food;
        timeTaken = Time.time - timeStarted;
        orderPrepared = true;
    }

    // Modifies player score, which is the maximum between 0 and the current score + the points earned from completing an order
    public static void UpdateScore(int scoreChange) {
        totalScore = Mathf.Max(0, totalScore + scoreChange);
    }

    // Resets all order-related state
    public static void ResetOrder() {
        expectedDrink = "";
        expectedFood = "";
        servedDrink = null;
        servedFood = null;
        orderPrepared = false;
        timeStarted = 0;
        timeTaken = 0;
    }
}