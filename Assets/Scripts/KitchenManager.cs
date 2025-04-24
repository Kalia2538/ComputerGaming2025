/**
* Author: Hana Ismaiel, Kalia Brown, Elysa Hines
* Date Created: 04/16/2025
* Date Last Updated: 04/23/2025
* Summary: Handles kitchen scene logic and return to cafe transition
*/

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KitchenManager : MonoBehaviour  {
    [Header("UI References")]
    public Button doneButton;

    [Header("Audio")]
    public AudioSource buttonClickSound;

    void Start() {
        doneButton.onClick.AddListener(ReturnToCafe);
    }

    // Transition back to cafe and update score
    void ReturnToCafe()  {
        if (buttonClickSound != null) {
            buttonClickSound.Play();
        }
        GameManager.orderPrepared = true;
        GameManager.servedDrink = DrinkMachine.GetDrinkName();
        GameManager.servedFood = FoodItem.GetFoodName();

        DrinkMachine.ClearDrink();
        FoodItem.ClearFood();

        SceneManager.LoadScene("cafe_v2_with_characters");
    }
}