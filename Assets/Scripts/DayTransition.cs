/**
* Author: Hana Ismaiel, Kalia Brown, Elysa Hines
* Date Created: 04/23/2025
* Date Last Updated: 04/24/2025
* Summary: Handles scene transition for each new day
*/

using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DayTransition : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI dayText;
    public Button startButton;
    public Button continueButton;
    public Button resetButton;

    private static bool isFirstPlay = true;

    void Start()
    {
        dayText.text = $"Day {GameManager.currentDay}";

        if (isFirstPlay)
        {
            startButton.gameObject.SetActive(true);
            continueButton.gameObject.SetActive(false);
            resetButton.gameObject.SetActive(false);
        }
        else
        {
            startButton.gameObject.SetActive(false);
            continueButton.gameObject.SetActive(true);
            resetButton.gameObject.SetActive(true);
        }

        startButton.onClick.AddListener(StartGame);
        continueButton.onClick.AddListener(ContinueGame);
        resetButton.onClick.AddListener(ResetGame);
    }

    void StartGame()
    {
        isFirstPlay = false;
        GameManager.ResetAllProgress();
        FindFirstObjectByType<SceneController>().GoToCafe();
    }

    void ContinueGame()
    {
        FindFirstObjectByType<SceneController>().GoToCafe();
    }

    void ResetGame()
    {
        GameManager.ResetAllProgress();
        isFirstPlay = true;
        FindFirstObjectByType<SceneController>().GoToDayTransition();
    }
}
