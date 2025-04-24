/**
* Authors: Hana Ismaiel, Kalia Brown, Elysa Hines
* Date Created: 04/24/2025
* Date Last Updated: 04/24/2025
* Summary: Control animation of clock
*/
using UnityEngine;

public class ClockAnimator : MonoBehaviour
{
    private Animator animator;
    private bool hasShaken = false;

    void Start() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        // Animate when day is halfway (or more) through
        if (GameManager.customersServedToday >= GameManager.CUSTOMERS_PER_DAY/2) {
            animator.SetTrigger("Shake");
        }
    }
}