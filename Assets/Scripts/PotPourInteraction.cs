using UnityEngine;

public class PotPourInteraction : MonoBehaviour
{
    public Animator animator;
    public AudioSource pickupSource;
    public AudioClip pickupClip;

    public AudioSource pouringSource;
    public AudioClip pouringClip;

    public ParticleSystem endParticles;

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
            else
            {
                Debug.LogWarning("Coffee child not found in cup hierarchy.");
            }
        }

        isPouring = false;
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