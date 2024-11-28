using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkForeward : MonoBehaviour
{
    [SerializeField]
    private float speed; // Speed of the character
    private waveSpawn wavespawn;
    private float countdown=5f;
    // Start is called before the first frame update
    //void Start()
    //{
    //    //transform.position = new Vector3(3, 3, 3);
    //}

    // Update is called once per frame
    private void Start()
    {
        wavespawn = GetComponentInParent<waveSpawn>();
    }
    void Update()
    {
        // Move the character forward along the z-axis
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            Destroy(gameObject);

            wavespawn.waves[wavespawn.currentWave].enemiesCount--;
        }
    }
}