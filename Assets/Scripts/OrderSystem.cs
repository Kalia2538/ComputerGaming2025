/**
* Authors: Hana Ismaiel, Kalia Brown, Elysa Hines
* Date Created: 04/16/2025
* Date Last Updated: 04/16/2025
* Summary: Handles drink spawning for espresso machine interactions
*/

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OrderSystem : MonoBehaviour {
    public TextMeshProUGUI orderText; 
    public Button okButton;
    public Button goToKitchenButton;

    private string customerOrder;
    private string drink;
    private string food;


    void Start() {
        // Generate a random order
        drink = GenerateDrink();
        food = GenerateFood();
        orderText.text = "Can I get a " + drink + " and a " + food + "?";
        goToKitchenButton.gameObject.SetActive(false);

        // Add button listeners
        okButton.onClick.AddListener(ConfirmOrder);
        goToKitchenButton.onClick.AddListener(GoToKitchen);
    }

    string GenerateDrink() {
        string[] drinks = { "Coffee", "Tea" };
        return drinks[Random.Range(0, drinks.Length)];
    }

    string GenerateFood() {
        string[] foods = { "Croissant", "Cupcake", "Donut", "Macaron" };
        return foods[Random.Range(0, foods.Length)]; 
    }

    void ConfirmOrder() {
        // Hide OK button and show "Go to Kitchen" button
        okButton.gameObject.SetActive(false);
        goToKitchenButton.gameObject.SetActive(true);
    }

    void GoToKitchen() {
        // Debug.Log("Going to kitchen...");

        // Here you can load a new scene or trigger kitchen mechanics
    }
}
