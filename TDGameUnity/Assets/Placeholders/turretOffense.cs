using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class turretOffense : turretBase
{

    private GameObject furthestTarget;
    private 
    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected GameObject getFurthest(int range)
    {
        GameObject furthestTarget = null;
        int furthestdistance = 1000000000;
        foreach (Collider target in Physics.OverlapSphere(transform.position, range))
        {
            if (target.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("hitting");
                if (target.gameObject.GetComponent<enemyPlaceholder>().distanceLeft < furthestdistance)
                {
                    furthestdistance = target.gameObject.GetComponent<enemyPlaceholder>().distanceLeft;
                    furthestTarget = target.gameObject;
                    
                }
            }
        }
        return furthestTarget;
    }

}
