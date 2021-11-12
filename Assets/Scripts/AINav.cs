using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AINav : MonoBehaviour
{

    public Transform player;
    NavMeshAgent agent;
    Animator animator;

   
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        agent.destination = PickRandomPosition();
    }

    void Update()
    {

        animator.SetFloat("Speed", agent.velocity.magnitude);

        if (CanSeePlayer())
        {
            // follows player
            agent.destination = player.position;
        }
        else
        {
            // walks to random positions
            if (agent.remainingDistance < 0.5f)
            {
                agent.destination = PickRandomPosition();
            }
        }

        
    }

    // Ai agent picks random position on map
    Vector3 PickRandomPosition()
    {
        Vector3 destination = transform.position;
        Vector2 randomDirection = UnityEngine.Random.insideUnitCircle * 100.0f;
        destination.x += randomDirection.x;
        destination.z += randomDirection.y;

        NavMeshHit navHit;
        NavMesh.SamplePosition(destination, out navHit, 100.0f, NavMesh.AllAreas);

        return navHit.position;
    }

    // Checks if agent can see player
    bool CanSeePlayer()
    {

        Vector3 rayPos = transform.position;
        Vector3 rayDir = (player.transform.position - rayPos).normalized;
        RaycastHit info;

        if (Physics.Raycast(rayPos, rayDir, out info))
        {
            if (info.transform.CompareTag("Player"))
            {
                return true;
            }

        }

        return false;
    }

}
