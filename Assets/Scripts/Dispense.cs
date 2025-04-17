/**
* Author: Hana Ismaiel
* Date Created: 03/20/2025
* Date Last Updated: 04/16/2025
* Summary: Manages cup dispensing mechanics with click interaction
*/

using UnityEngine;

public class Dispense : MonoBehaviour {
    public string cupSize; // Either "Small", "Medium", or "Large"
    public CupSpawner cupSpawner;

    private static bool coffeeDispensed = false; // Track if coffee has been dispensed

    void OnMouseDown() {
        if (CupSpawner.GetSpawnedCup() == null) {
            Debug.Log("Please place a cup first");
            return; // Do nothing if no cup is placed
        } else if (coffeeDispensed) {
            Debug.Log("Coffee has already been dispensed");
            return; // Prevent multiple dispensing
        } else {
            DispenseLiquid(CupSpawner.GetSpawnedCup(), cupSize);
            coffeeDispensed = true;
        }
    }

    void DispenseLiquid(GameObject cup, string size) {
        Debug.Log($"Dispensing coffee based on size {size}");
    }
}
