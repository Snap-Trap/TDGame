using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class turretOffense : turretBase
{
    protected int attackrate;
    protected bool canFire;
    protected bool canShoot;

    public LayerMask whatIsEnemy;

    [SerializeField] protected int firingMode;
    // Start is called before the first frame update
    void Start()
    {
        whatIsEnemy = LayerMask.GetMask("enemyLayer");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected GameObject getFirst(int range)
    {
        GameObject furthestTarget = null;
        int furthestdistance = 1000000000;
        foreach (Collider target in Physics.OverlapSphere(transform.position, range))
        {
            if (target.gameObject.CompareTag("Enemy"))
            {
                if (target.gameObject.GetComponent<enemyPlaceholder>().distanceLeft < furthestdistance)
                {
                    furthestdistance = target.gameObject.GetComponent<enemyPlaceholder>().distanceLeft;
                    furthestTarget = target.gameObject;
                    
                }
            }
        }
        return furthestTarget;
    }

    protected GameObject getLast(int range)
    {
        GameObject furthestTarget = null;
        int furthestdistance = 0;
        foreach (Collider target in Physics.OverlapSphere(transform.position, range))
        {
            if (target.gameObject.CompareTag("Enemy"))
            {
                if (target.gameObject.GetComponent<enemyPlaceholder>().distanceLeft > furthestdistance)
                {
                    furthestdistance = target.gameObject.GetComponent<enemyPlaceholder>().distanceLeft;
                    furthestTarget = target.gameObject;

                }
            }
        }
        return furthestTarget;
    }
    protected GameObject getToughest(int range)
    {
        GameObject furthestTarget = null;
        int highestHealth = 0;
        foreach (Collider target in Physics.OverlapSphere(transform.position, range))
        {
            if (target.gameObject.CompareTag("Enemy"))
            {
                if (target.gameObject.GetComponent<enemyPlaceholder>().Health > highestHealth)
                {
                    highestHealth = target.gameObject.GetComponent<enemyPlaceholder>().distanceLeft;
                    furthestTarget = target.gameObject;

                }
            }
        }
        return furthestTarget;
    }

    IEnumerator Fire()
    {
        if (canFire)
        {


            if (Physics.OverlapSphere(transform.position, range, ~whatIsEnemy) != null)
            {

                Debug.Log("hitting");
                if (firingMode == 1)
                {
                    Debug.Log(getToughest(range).name);
                }
                else if (firingMode == 2)
                {
                    Debug.Log(getLast(range).name);
                }
                else
                {
                    Debug.Log(getFirst(range).name);
                }

                yield return new WaitForSeconds(10.0f / attackrate);

                StartCoroutine(Fire());
            }
            else
            {
                yield return new WaitForSeconds(0.2f);



                StartCoroutine(Fire());
            }

        }

    }

}
