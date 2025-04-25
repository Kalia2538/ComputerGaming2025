using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class TestMesh : MonoBehaviour
{
    private Vector3 target;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (agent == null)
        {
            Debug.LogError("Missing NavMeshAgent component!");
            return;
        }

        if (target == null)
        {
            Debug.LogError("Target GameObject is not assigned!");
            return;
        }

        if (!agent.isOnNavMesh)
        {
            Debug.LogError("Customer is NOT on a baked NavMesh!");
            return;
        }

        target = new Vector3(35f, -38f, 2f);
        agent.SetDestination(target);
    }

    void Update()
    {
        if (target != null && agent.enabled && agent.isOnNavMesh)
        {
            agent.SetDestination(target);
        }
    }
}
