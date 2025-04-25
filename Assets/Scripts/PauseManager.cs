/**
Elysa Hines  
Date Created: 04/24/25  
Date Last Updated: 04/24/25
Summary: Handles the pause menu, volume control, and switching to home screen.
*/

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PauseManager : MonoBehaviour {
    public GameObject pauseMenuUI;
    public Slider musicSlider;
    public AudioSource musicSource;

    private bool isPaused = false;
    public AudioMixer musicMixer;

    void Start() {
        if (musicSlider != null && musicMixer != null) {
            float currentDb;
            if (musicMixer.GetFloat("MusicVolume", out currentDb)) {
                musicSlider.value = Mathf.Pow(10f, currentDb / 20f); // Convert dB to 0–1
            }
        }
    }


    public void SetMusicVolume(float sliderValue) {

        sliderValue = Mathf.Clamp(sliderValue, 0.0001f, 1f);
        float volumeInDb = Mathf.Log10(sliderValue) * 20f;
        musicMixer.SetFloat("MusicVolume", volumeInDb);
    }


// both the pause button or escape work to pause
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused) ResumeGame();
            else PauseGame();
        }
    }

    public void PauseGame() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        AudioListener.pause = true;
        isPaused = true;
    }

    public void ResumeGame() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.pause = false;
        isPaused = false;
    }

    public void QuitToMainMenu() {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        SceneManager.LoadScene("DayTransition"); 
    }

    void Awake() {
    DontDestroyOnLoad(this.gameObject);
}

}

