using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public float speed, health;

    private Vector3 walkPoint, enemyDestination;

    [SerializeField] private bool walkpointSet;

    private LayerMask whatIsPath;
    
    private NavMeshAgent agent;

    private void Start()
    {
        whatIsPath = LayerMask.GetMask("pathLayer");
        enemyDestination = GameObject.Find("EnemyDestination").transform.position;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    private void Update()
    {
        if (!walkpointSet)
        {
            SearchWalkPoint();
        }   

        else
        {
            agent.SetDestination(walkPoint);
        }
    }

    private void SearchWalkPoint()
    {
        walkPoint = new Vector3(enemyDestination.x, enemyDestination.y, enemyDestination.z);
        walkpointSet = true;
    }
}
