using UnityEngine;

// class to keep track of the game state variables
public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    public static string expectedDrink; // drink that the customer ordered
    public static string expectedFood; // food that the customer ordered
    public static string servedDrink; // drink that the player prepared
    public static string servedFood; // food that the player prepared
    public static float timeStarted; // time that order was recieved
    public static float timeTaken; // total time taken to make and serve the order
    public static bool orderPrepared = false;
    public static int totalScore = 0;

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    // set variables once order is completed
    public static void OrderCompleted(string drink, string food) {
        servedDrink = drink;
        servedFood = food;
        timeTaken = Time.time - timeStarted;
        orderPrepared = true;
    }

    // update player's score
    public static void UpdateScore(int scoreChange) {
        totalScore += scoreChange;
    }
}

