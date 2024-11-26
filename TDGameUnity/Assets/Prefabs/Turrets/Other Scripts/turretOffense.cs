using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class turretOffense : turretBase
{
    [SerializeField] protected int attackrate;
    [SerializeField] protected int blastradius;
    [SerializeField] protected int damage;

    [SerializeField] protected bool explosive;

    [SerializeField] protected LayerMask enemyMask;

    protected bool canFire = true;
    protected bool canShoot;

    

    private LayerMask whatIsEnemy;

    [SerializeField] protected int firingMode;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected GameObject getFirst(int range)
    {
        GameObject furthestTarget = null;
        int furthestdistance = 1000000000;
        foreach (Collider target in Physics.OverlapSphere(transform.position, range, enemyMask))
        {

            if (target.gameObject.GetComponent<enemyPlaceholder>().distanceLeft < furthestdistance)
            {
                    furthestdistance = target.gameObject.GetComponent<enemyPlaceholder>().distanceLeft;
                    furthestTarget = target.gameObject;
                    
            }
            
        }
        return furthestTarget;
    }

    protected GameObject getLast(int range)
    {
        GameObject furthestTarget = null;
        int furthestdistance = 0;
        foreach (Collider target in Physics.OverlapSphere(transform.position, range, enemyMask))
        {
            if (target.gameObject.GetComponent<enemyPlaceholder>().distanceLeft > furthestdistance)
            {
                furthestdistance = target.gameObject.GetComponent<enemyPlaceholder>().distanceLeft;
                furthestTarget = target.gameObject;

            }
            
        }
        return furthestTarget;
    }
    protected GameObject getToughest(int range)
    {
        GameObject furthestTarget = null;
        int highestHealth = 0;
        foreach (Collider target in Physics.OverlapSphere(transform.position, range, enemyMask))
        {

            if (target.gameObject.GetComponent<enemyPlaceholder>().Health > highestHealth)
            {
                highestHealth = target.gameObject.GetComponent<enemyPlaceholder>().distanceLeft;
                furthestTarget = target.gameObject;

            }
            
        }
        return furthestTarget;
    }

    IEnumerator Fire()
    {
        Debug.Log("Firing");
        if (canFire)
        {
            GameObject firingtarget = null;

            if (Physics.OverlapSphere(transform.position, range, enemyMask).Count() != 0)
            {

                if (firingMode == 1)
                {
                    firingtarget = getToughest(range);
                }
                else if (firingMode == 2)
                {
                    firingtarget = getLast(range);
                }
                else
                {
                    firingtarget = getFirst(range);
                }

                if (!explosive)
                {
                    firingtarget.GetComponent<EnemyStats>().health = -damage;
                }
                else
                {
                    foreach(Collider target in Physics.OverlapSphere(firingtarget.transform.position, blastradius, 1 << 8))
                    {
                        firingtarget.GetComponent <EnemyStats>().health = -damage;
                    }
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
