/**
Author: Elysa Hines  
Date Created: 03/30/25  
Date Last Updated: 04/16/25 
Summary: Handles the brewing process for coffee, including particle effects, audio playback, and cup filling logic.
*/

using UnityEngine;
using System.Collections;

public class BrewButton : MonoBehaviour
{
    [Header("Visual Effects")]
    public ParticleSystem espressoStream;
    public ParticleSystem coffeeSteam;

    [Header("Audio Components")]
    public AudioSource streamAudioSource;
    public AudioClip streamAudioClip;

    [Header("Brew Settings")]
    public float brewDuration = 2f;

    void OnMouseDown()
    {
        GameObject cup = DrinkMachine.GetSpawnedCup();

        if (cup != null)
        {
            StartCoroutine(BrewCoffee(cup));
        }
        else
        {
            // Debug warning if player presses brew without placing cup
            Debug.Log("No cup to fill!"); 
        }
    }

    IEnumerator BrewCoffee(GameObject cup)
    {
        if (espressoStream != null)
            espressoStream.Play();

        if (streamAudioSource != null)
        {
            if (streamAudioClip != null)
                streamAudioSource.clip = streamAudioClip;

            streamAudioSource.loop = true;
            streamAudioSource.Play();
        }

        yield return new WaitForSeconds(brewDuration);

        Transform coffee = FindChildRecursive(cup.transform, "coffee in cup");
        if (coffee != null)
        {
            coffee.gameObject.SetActive(true);
        }

        Transform steam = FindChildRecursive(cup.transform, "coffeeSteam");
        if (steam != null)
        {
            steam.gameObject.SetActive(true);
            // Confirms steam VFX is found and triggered
            Debug.Log("Steam showing!"); 
        }
        else
        {
            // Helps identify if prefab hierarchy is incorrect
            Debug.LogWarning("Steam not found in cup!");
        }

        if (espressoStream != null)
            espressoStream.Stop();

        if (streamAudioSource != null)
            streamAudioSource.Stop();
         // Confirms brewing ended
        Debug.Log("Coffee brewed!");
    }

    // Works to find the the "coffee in cup" name to make visible after brewing
    Transform FindChildRecursive(Transform parent, string name)
    {
        foreach (Transform child in parent)
        {
            if (child.name == name) return child;
            Transform found = FindChildRecursive(child, name);
            if (found != null) return found;
        }
        return null;
    }
}