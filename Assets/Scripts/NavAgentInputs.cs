using System.Collections;
using System.Collections.Generic;
using Controller;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavAgentInputs : MonoBehaviour
{
    private NavMeshAgent agent;
    private CharacterMover mover;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        mover = GetComponent<CharacterMover>();

        // no additional movement
        agent.updatePosition = false;
        agent.updateRotation = false;
    }
    // Update is called once per frame
    void Update()
    {
        // if we've reached our destination or are calculating a path, don't move the character
        if (agent.pathPending || agent.remainingDistance < 0.1f) {
            mover.SetInput(Vector2.zero, transform.position, false, false);
            return;
        }

        Vector3 direction = agent.desiredVelocity.normalized;

        Vector2 axis= new Vector2(direction.x, direction.z);

        mover.SetInput(axis, agent.steeringTarget, false, false);
    }

    private void LateUpdate()
    {
        agent.nextPosition = transform.position;
    }

    // does this need ot be its own function???
    public void SetDestination(Vector3 point) { 
        agent.SetDestination(point);
    }


}
