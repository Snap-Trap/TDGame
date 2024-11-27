using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    EnemyStats enemyStats;

    private float distanceTraveled;

    private Vector3 walkPoint, enemyDestination;

    [SerializeField] private bool walkpointSet;

    private LayerMask whatIsPath;
    
    private NavMeshAgent agent;

    private void Start()
    {
        whatIsPath = LayerMask.GetMask("pathLayer");
        enemyDestination = GameObject.Find("EnemyDestination").transform.position;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {   
        distanceTraveled += agent.velocity.magnitude * Time.deltaTime;

        Debug.Log(distanceTraveled);

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EndOfPath"))
        {
           StartCoroutine(WaitBeforeDestroy());
        }
    }

    IEnumerator WaitBeforeDestroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        Debug.Log("Enemy reached the end of the line");
    }
}
