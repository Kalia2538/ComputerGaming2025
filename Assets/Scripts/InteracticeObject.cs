using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public GameObject uiPrompt; // Assign a UI element in the Inspector

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger");
            uiPrompt.SetActive(true);
            // Optionally notify the player’s interaction script that this object is available
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Player exited trigger");
            uiPrompt.SetActive(false);
        }
    }

    public void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);
        // Place your interaction logic here (e.g., dispensing a drink)
    }
}
