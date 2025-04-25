using UnityEngine;

public class SceneController : MonoBehaviour
{
    [Header("Scene Groups")]
    public GameObject cafeGroup;
    public GameObject kitchenGroup;
    public GameObject dayTransitionGroup;

    void Start()
    {
        // Optional: start in day transition
        GoToDayTransition();
    }

    public void GoToCafe()
    {
        cafeGroup.SetActive(true);
        kitchenGroup.SetActive(false);
        dayTransitionGroup.SetActive(false);
    }

    public void GoToKitchen()
    {
        cafeGroup.SetActive(false);
        kitchenGroup.SetActive(true);
        dayTransitionGroup.SetActive(false);
    }

    public void GoToDayTransition()
    {
        cafeGroup.SetActive(false);
        kitchenGroup.SetActive(false);
        dayTransitionGroup.SetActive(true);
    }
}
