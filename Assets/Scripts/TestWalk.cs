using UnityEngine;
using Controller;

public class WalkForwardTest : MonoBehaviour
{
    private CharacterMover characterMover;

    void Start()
    {
        characterMover = GetComponent<CharacterMover>();
        if (characterMover == null)
        {
            Debug.LogError("CharacterMover not found on this GameObject.");
        }
    }

    void Update()
    {
        if (characterMover != null)
        {
            // Forward movement in local space (0 on x, 1 on y means "forward")
            Vector2 axis = new Vector2(0f, 1f);

            // The look target — just something forward in world space
            Vector3 lookTarget = transform.position + transform.forward * 10f;

            bool isRunning = false;
            bool isJumping = false;

            characterMover.SetInput(axis, lookTarget, isRunning, isJumping);
        }
    }
}
