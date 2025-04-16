using UnityEngine;
using System.Collections;

public class BrewButton : MonoBehaviour
{
    public ParticleSystem espressoStream;
    public ParticleSystem coffeeSteam;

    public AudioSource streamAudioSource;
    public AudioClip streamAudioClip;

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
            Debug.Log("Steam showing!");
        }
        else
        {
            Debug.LogWarning("Steam not found in cup!");
        }

        if (espressoStream != null)
            espressoStream.Stop();

        if (streamAudioSource != null)
            streamAudioSource.Stop();

        Debug.Log("Coffee brewed!");
    }

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

