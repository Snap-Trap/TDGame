using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi2 : MonoBehaviour, IDamageable
{
    private gameOverScript gameOverScript;
    private CoinUpdate coinUpdate;

    public float distanceTraveled, health;

    public int coinDrop, baseDamage;

    private Vector3 walkPoint, enemyDestination;

    [SerializeField] private bool walkpointSet;

    private LayerMask whatIsPath;

    private NavMeshAgent agent;

    //---------------------
    private waveSpawn wavespawn;


    private void Start()
    {
        gameOverScript = GameObject.Find("EnemyDestination").GetComponent<gameOverScript>();
        coinUpdate = GameObject.Find("Canvas").GetComponent<CoinUpdate>();
        whatIsPath = LayerMask.GetMask("pathLayer");
        enemyDestination = GameObject.Find("EnemyDestination").transform.position;
        agent = GetComponent<NavMeshAgent>();
        //---------------------
        wavespawn = GetComponentInParent<waveSpawn>();
    }

    private void Update()
    {
        distanceTraveled += agent.velocity.magnitude * Time.deltaTime;

        //Debug.Log(distanceTraveled);

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
            gameOverScript.baseHealth -= baseDamage;
            StartCoroutine(WaitBeforeDestroy());
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            coinUpdate.coins += coinDrop;
            Destroy(gameObject);
            Debug.Log("THY END IS NOW!!!");
            //---------------------
            wavespawn.waves[wavespawn.currentWave].enemiesCount--;
        }
    }

    IEnumerator WaitBeforeDestroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        Debug.Log("Enemy reached the end of the line");
        //---------------------
        wavespawn.waves[wavespawn.currentWave].enemiesCount--;
    }
}
