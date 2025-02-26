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
