/**
* Author: Elysa Hines
* Date Created: 04/22/2025
* Summary: Tracks the drink and food items the player has prepared for delivery.
*/

using UnityEngine;

public static class ItemManager
{
    private static string preparedDrink = "";
    private static string preparedFood = "";

    //when a drink is successfully brewed
    public static void SetPreparedDrink(string drinkType)
    {
        preparedDrink = drinkType;
        // Debug.Log("Prepared drink set to: " + drinkType);
    }

    //when a food item is spawned/prepared
    public static void SetPreparedFood(string foodType)
    {
        preparedFood = foodType;
        // Debug.Log("Prepared food set to: " + foodType);
    }

    public static string GetPreparedDrink()
    {
        return preparedDrink;
    }

    public static string GetPreparedFood()
    {
        return preparedFood;
    }

    public static void Reset()
    {
        preparedDrink = "";
        preparedFood = "";
    }
}
