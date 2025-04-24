/**
* Authors: Hana Ismaiel, Kalia Brown, Elysa Hines
* Date Created: 04/16/2025
* Date Last Updated: 04/16/2025
* Summary: Controls door animations with manual and automatic triggers
*/

using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DoorSwing : MonoBehaviour {
    private Animator animator;
    private bool isOpen = false;

    void Start() {
        animator = GetComponent<Animator>();
    }

    public void ToggleDoor() {
        isOpen = !isOpen;
        animator.SetBool("isOpen", isOpen);
    }

    public void OpenDoor() {
        if (!isOpen) {
            isOpen = true;
            animator.SetTrigger("Open");
        }
    }

    public void CloseDoor() {
        if (isOpen) {
            isOpen = false;
            animator.SetTrigger("Close");
        }
    }
}