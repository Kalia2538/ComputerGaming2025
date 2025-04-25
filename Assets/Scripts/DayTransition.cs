/**
* Author: Hana Ismaiel, Kalia Brown, Elysa Hines
* Date Created: 04/23/2025
* Date Last Updated: 04/24/2025
* Summary: Handles scene transition for each new day
*/

using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        
        // Show appropriate buttons
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

        // Set up button listeners
        startButton.onClick.AddListener(StartGame);
        continueButton.onClick.AddListener(ContinueGame);
        resetButton.onClick.AddListener(ResetGame);
    }

    void StartGame()
    {
        isFirstPlay = false;
        GameManager.ResetAllProgress();
        SceneManager.LoadScene("cafe_v2_with_characters");
    }

    void ContinueGame()
    {
        SceneManager.LoadScene("cafe_v2_with_characters");
    }

    void ResetGame()
    {
        GameManager.ResetAllProgress();
        isFirstPlay = true;
        SceneManager.LoadScene("DayTransition");
    }
}