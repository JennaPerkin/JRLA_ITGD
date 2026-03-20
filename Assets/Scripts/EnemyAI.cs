using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;
    public LayerMask ground, player;

    [Header("Patrolling")]
    public Vector3 walkPoint;
    bool isWalkPointSet;
    public float walkPointRange;

    [Header("States")]
    public float chaseRange;
    bool isPlayerInChaseRange;
    // Start is called before the first frame update
    void Start()
    {
        //make sure NavMesh Agent is attached to Enemy
        //If you do not see a Nav Mesh Agent Component, install NavMesh from Package Manager, Unity Registry
        agent = GetComponent<NavMeshAgent>();
        if(agent == null)
        {
            Debug.LogWarning("Add Nav Mesh Agent Component to Enemy");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //checks if player is within chaseRange variable
        isPlayerInChaseRange = Physics.CheckSphere(transform.position, chaseRange, player);
        //if player is within chaseRange, we set enemy to run the Chasing Function
        if (isPlayerInChaseRange) Chasing();
        //if the player is not within chaseRange, we set the enemy to Patrolling
        else Patrolling();
    }

    private void Patrolling()
    {
        //If we don't have a walk point, we search for one
        //We won't have a walk point on the first time we run the code, meaning SearchWalkPoint will call the first time
        if (!isWalkPointSet) SearchWalkPoint();
        else
            //If we have a walk point, we set the destination of the enemy to that point.
            agent.SetDestination(walkPoint);

        //calculating distance to walk point by subtracting walk point location from current position
        // when we are within 2 units of the walk point, we set isWalkPointSet to false, triggering a search for a new walk point
        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if (distanceToWalkPoint.magnitude < 2f)
            isWalkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        //finds 2 random points within our walk point range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        //creates a walk point with our two random points
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        //checks if walk point is above ground
        if (Physics.Raycast(walkPoint, -transform.up, 2f, ground))
            isWalkPointSet = true;
    }


    private void Chasing()
    {
        //if enemy is close to the player, they move to the player. This function cancels automatically when the player is far enough away.
        agent.SetDestination(target.position);
    }
}
