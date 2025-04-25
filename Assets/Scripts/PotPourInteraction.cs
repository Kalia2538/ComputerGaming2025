/**
Elysa Hines  
Date Created: 04/14/25  
Date Last Updated: 04/22/25
Summary: Handles pot pickup and pouring interaction with animation, sound, and particle effects. Fills a target cup when finished.
*/

using UnityEngine;

public class PotPourInteraction : MonoBehaviour
{
    [Header("Drink Type")]
    public string drinkType = "tea"; 

    [Header("Animation")]
    public Animator animator;

    [Header("Pickup Sound")]
    public AudioSource pickupSource;
    public AudioClip pickupClip;

    [Header("Pouring Sound")]
    public AudioSource pouringSource;
    public AudioClip pouringClip;

    [Header("Effects")]
    public ParticleSystem endParticles;

    [Header("Target Settings")]
    public GameObject cupObject;
    public float brewDuration = 3f;

    private bool isPouring = false;

    void OnMouseDown()
    {
        if (isPouring) return;

        isPouring = true;

        if (pickupSource && pickupClip)
            pickupSource.PlayOneShot(pickupClip);

        animator.SetTrigger("StartPour");

        // Small delay before audio starts to sync with animation
        Invoke(nameof(StartPouring), 0.3f);
        Invoke(nameof(EndPouring), brewDuration);
    }

    void StartPouring()
    {
        if (pouringSource && pouringClip)
        {
            pouringSource.clip = pouringClip;
            pouringSource.loop = true;
            pouringSource.Play();
        }
    }

    void EndPouring()
    {
        if (pouringSource)
            pouringSource.Stop();

        animator.SetTrigger("ResetPot");

        if (endParticles != null)
            endParticles.Play();

        if (cupObject != null)
        {
            Transform coffee = FindChildRecursive(cupObject.transform, "coffee");
            if (coffee != null)
            {
                coffee.gameObject.SetActive(true);
            }
            // else
            // {
            //     // Failsafe to catch hierarchy issues
            //     Debug.LogWarning("Coffee child not found in cup hierarchy.");
            // }
        }

        isPouring = false;
        if (!string.IsNullOrEmpty(drinkType))
        {
            ItemManager.SetPreparedDrink(drinkType.ToLower());
        }
        // else
        // {
        //     Debug.LogWarning("Drink type not set for this pour interaction!");
        // }


    }

    // Works to find the the "coffee" name to make visible after brewing
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

