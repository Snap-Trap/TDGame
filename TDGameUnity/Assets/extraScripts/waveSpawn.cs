using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveSpawn : MonoBehaviour
{
    [SerializeField] private float countdown;
    [SerializeField] private GameObject spawnPoint;
    public Wave[] waves;

    public int currentWave = 0;

    private bool readyToCountdown;
    private void Start()
    {
        readyToCountdown = true;
        for (int i = 0; i < waves.Length; i++)
            waves[i].enemiesCount = waves[i].enemies.Length;
    }
    private void Update()
    {
        Debug.Log("Update method called");
        if (currentWave >= waves.Length)
        {
            Debug.Log("All waves spawned");
            return;
        }
        if (readyToCountdown)
        {
            countdown -= Time.deltaTime;
            //Debug.Log("Countdown: " + countdown);
        }
        if (countdown <= 0)
        {
            readyToCountdown = false;
            countdown = waves[currentWave].timeToNextWave;
            StartCoroutine(SpawnWave());
            Debug.Log("Spawning wave: " + currentWave);
        }
        if (waves[currentWave].enemiesCount == 0)
        {
            readyToCountdown = true;
            currentWave++;
            Debug.Log("Next wave: " + currentWave);
        }
    }
    private IEnumerator SpawnWave()
    {
        if (currentWave < waves.Length)
        {
            Debug.Log("Spawning wave: " + currentWave);
            for (int i = 0; i < waves[currentWave].enemies.Length; i++)
            {
                EnemyAi2 enemy = Instantiate(waves[currentWave].enemies[i], spawnPoint.transform);
                enemy.transform.SetParent(spawnPoint.transform);
                Debug.Log("Spawned enemy: " + i);
                yield return new WaitForSeconds(waves[currentWave].timeToNextEnemy);
            }
        }
    }
}
[System.Serializable]
public class Wave
{
    public EnemyAi2[] enemies;
    public float timeToNextEnemy;
    public float timeToNextWave;

    public int enemiesCount;
}