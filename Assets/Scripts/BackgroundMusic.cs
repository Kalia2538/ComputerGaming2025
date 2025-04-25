using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

/**
    Authors: Hana Ismaiel, Kalia Brown, Elysa Hines
    Date Created: 4/16/2025
    Date Last Updated: 4/16/2025
    Summary: changes the music snapshot based on the current scene
*/

public class BackgroundMusic : MonoBehaviour
{
    public AudioMixer backgroundMixer;
    public static BackgroundMusic Instance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        // keeps the background music playing when we switch scenes
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        switch (scene.name) {
            case "cafe_v2_with_characters":
                backgroundMixer.TransitionToSnapshots(
                    new AudioMixerSnapshot[] {
                            backgroundMixer.FindSnapshot("Cafe")
                    }, new float[] { 1f },
                    0.5f
                    );
                    break;
            case "Kitchen":
                backgroundMixer.TransitionToSnapshots(
                    new AudioMixerSnapshot[] {
                            backgroundMixer.FindSnapshot("Cafe")
                    }, new float[] { 1f },
                    0.5f
                    );
                break;
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
