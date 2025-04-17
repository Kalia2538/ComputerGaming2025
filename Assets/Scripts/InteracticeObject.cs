/**
* Authors: Hana Ismaiel, Kalia Brown, Elysa Hines
* Date Created: 04/16/2025
* Date Last Updated: 04/16/2025
* Summary: Handles drink spawning for espresso machine interactions
*/

using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public GameObject uiPrompt; //assigning a UI element in inspector

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger");
            uiPrompt.SetActive(true);
            //notifying the player’s interaction script that this object is available
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
        // interaction logic here (e.g., dispensing a drink)
    }
}
