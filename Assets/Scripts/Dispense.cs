using UnityEngine;

// Class to manage dispensing coffee into a cup
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
