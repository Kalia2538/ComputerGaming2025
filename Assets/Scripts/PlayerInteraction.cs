/**
* Authors: Hana Ismaiel, Kalia Brown, Elysa Hines
* Date Created: 04/16/2025
* Date Last Updated: 04/16/2025
* Summary: Handles drink spawning for espresso machine interactions
*/

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    private InteractiveObject nearbyInteractive;

    // Called by trigger events on interactive objects
    public void SetNearbyInteractive(InteractiveObject obj)
    {
        nearbyInteractive = obj;
    }

    // Input callback for interaction (e.g., pressing Space)
    public void OnInteract(InputValue value)
    {
        if(value.isPressed && nearbyInteractive != null)
        {
            nearbyInteractive.Interact();
        }
    }
}
