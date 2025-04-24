/**
* Author: Elysa Hines
* Date Created: 04/24/2025
* Summary: Controls a hold-to-brew mechanic with slider UI, particle effects, and scoring logic.
*/

using UnityEngine;
using UnityEngine.UI;

public class PrecisionBrewController : MonoBehaviour
{
    [Header("Timing")]
    public float maxHoldTime = 3f;
    public Vector2 perfectRange = new Vector2(1.5f, 2.2f); // Ideal range for perfect brew

    [Header("UI")]
    public Slider brewSlider;
    public GameObject brewSliderObject; 

    [Header("Visual Effects")]
    public ParticleSystem espressoStream;
    public GameObject cupObject;
    public float delayBeforeSteam = 0.3f;

    private float holdTimer = 0f;
    private bool isHolding = false;

    private Transform coffeeInCup;
    private Transform steamInCup;
    private bool brewLocked = false;


    void Start()
    {
        brewSliderObject.SetActive(false);
        brewSlider.minValue = 0;
        brewSlider.maxValue = maxHoldTime;

        if (cupObject != null)
        {
            coffeeInCup = FindChildRecursive(cupObject.transform, "coffee in cup");
            steamInCup = FindChildRecursive(cupObject.transform, "coffeeSteam");

            if (coffeeInCup != null) coffeeInCup.gameObject.SetActive(false);
            if (steamInCup != null) steamInCup.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (isHolding && !brewLocked)
        {
            holdTimer += Time.deltaTime;
            brewSlider.value = holdTimer;

                if (!steamInCup.gameObject.activeSelf &&
                holdTimer >= perfectRange.x && holdTimer <= perfectRange.y)
            {
                ShowSteam();
                Debug.Log("You're in the perfect range!");
            }


            if (holdTimer >= maxHoldTime)
            {
                holdTimer = maxHoldTime; // clamp
                StopBrewing(); // triggers lock
            }
        }
    }

public void StartBrewing()
{
    if (brewLocked) return; 

    isHolding = true;
    brewSliderObject.SetActive(true);

    if (espressoStream != null && !espressoStream.isPlaying)
        espressoStream.Play();
}


public void StopBrewing()
{
    if (brewLocked) return; // Don’t double stop

    isHolding = false;

    if (espressoStream != null)
        espressoStream.Stop();

    // Evaluate only once — lock the brew if max time hit or user says "done"
    if (holdTimer >= maxHoldTime)
    {
        brewLocked = true;
        FinalizeBrew();
    }
}

void FinalizeBrew()
{
    brewSliderObject.SetActive(false);

    bool isPerfect = holdTimer >= perfectRange.x && holdTimer <= perfectRange.y;

    if (coffeeInCup != null)
        coffeeInCup.gameObject.SetActive(true);

    if (steamInCup != null)
        Invoke(nameof(ShowSteam), delayBeforeSteam);

    if (isPerfect)
    {
        Debug.Log("Perfect Brew!");
        ItemManager.SetPreparedDrink("espresso");
    }
    else
    {
        Debug.Log("Imperfect Brew.");
        ItemManager.SetPreparedDrink("burnt");
    }

    GameManager.orderPrepared = true;
}


    void ShowSteam()
    {
        if (steamInCup != null)
            steamInCup.gameObject.SetActive(true);
    }

    Transform FindChildRecursive(Transform parent, string name)
    {
        foreach (Transform child in parent)
        {
            if (child.name == name)
                return child;

            Transform found = FindChildRecursive(child, name);
            if (found != null)
                return found;
        }
        return null;
    }
}
