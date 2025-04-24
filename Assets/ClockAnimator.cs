using UnityEngine;

public class ClockAnimator : MonoBehaviour {
    private Animator animator;
    private bool hasShaken = false;

    void Start() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        int halfway = GameManager.CUSTOMERS_PER_DAY / 2;
        if (GameManager.customersServedToday == halfway && !hasShaken) {
            animator.SetTrigger("Shake");
            hasShaken = true;
        }
        
        // Reset for new day
        if (GameManager.customersServedToday == 0) {
            hasShaken = false;
        }
    }
}