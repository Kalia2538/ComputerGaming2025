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
    public static bool orderServed = false;
    public static int totalScore = 0;
    public static bool perfectOrder = false;
    public static int currentDay = 1;
    public static int customersServedToday = 0;
    public const int CUSTOMERS_PER_DAY = 8;
    

    void Awake()  {
        if (Instance == null)  {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else  {
            Destroy(gameObject);
        }
    }
    
    // Records completed order details and preparation time
    public static void CompleteOrder(string drink, string food) {
        servedDrink = drink;
        servedFood = food;
        timeTaken = Time.time - timeStarted;
        orderPrepared = true;
        orderServed = false;
    }

    // Modifies player score, calculate based on accuracy of order
    public static void CalculateAndAddScore() {
        int score = 0;
        if (servedDrink != null && servedDrink == expectedDrink) score += 50;
        if (servedFood != null && servedFood == expectedFood) score += 50;
        if (score == 100) perfectOrder = true;
        totalScore += score;
    }

    // Resets all order-related state
    public static void Reset() {
        expectedDrink = "";
        expectedFood = "";
        servedDrink = null;
        servedFood = null;
        orderPrepared = false;
        orderServed = false;
        perfectOrder = false;
        timeStarted = 0;
        timeTaken = 0;
    }

    public static void StartNewDay() {
        currentDay++;
        customersServedToday = 0;
        Reset();
    }

    public static bool ShouldEndDay() {
        return customersServedToday >= CUSTOMERS_PER_DAY;
    }
}
