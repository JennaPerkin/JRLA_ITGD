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
        agent = GetComponent<NavMeshAgent>();
        if(agent == null)
        {
            Debug.LogWarning("Add Nav Mesh Agent Component to Enemy");
        }
    }

    // Update is called once per frame
    void Update()
    {
        isPlayerInChaseRange = Physics.CheckSphere(transform.position, chaseRange, player);
        if (isPlayerInChaseRange) Chasing();
        else Patrolling();
    }

    private void Patrolling()
    {
        if (!isWalkPointSet) SearchWalkPoint();
        else
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if (distanceToWalkPoint.magnitude < 2f)
            isWalkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, ground))
            isWalkPointSet = true;
    }


    private void Chasing()
    {
        agent.SetDestination(target.position);
    }
}
