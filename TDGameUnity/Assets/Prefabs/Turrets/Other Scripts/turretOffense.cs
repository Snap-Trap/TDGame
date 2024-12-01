using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class turretOffense : turretBase
{
    public float highestMagnification;

    [SerializeField] protected int blastradius;

    [SerializeField] protected bool explosive;

    [SerializeField] protected float baseAttackRate;
    [SerializeField] protected float baseDamage;
    
    [SerializeField] protected LayerMask enemyMask;

    protected bool canFire = true;
    protected bool canShoot;

    protected float attackrate;
    protected float damage;

    protected List<GameObject> boosters = new List<GameObject>();

    

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

    protected GameObject getFirst(float range)
    {
        GameObject furthestTarget = null;
        float furthestdistance = 1000000000;
        foreach (Collider target in Physics.OverlapSphere(transform.position, range, enemyMask))
        {

            if (target.gameObject.GetComponent<EnemyAi>().distanceTraveled < furthestdistance)
            {
                    furthestdistance = target.gameObject.GetComponent<EnemyAi>().distanceTraveled;
                    furthestTarget = target.gameObject;
                    
            }
            
        }
        return furthestTarget;
    }

    protected GameObject getLast(float range)
    {
        GameObject furthestTarget = null;
        float furthestdistance = 0;
        foreach (Collider target in Physics.OverlapSphere(transform.position, range, enemyMask))
        {
            if (target.gameObject.GetComponent<EnemyAi>().distanceTraveled > furthestdistance)
            {
                furthestdistance = target.gameObject.GetComponent<EnemyAi>().distanceTraveled;
                furthestTarget = target.gameObject;

            }
            
        }
        return furthestTarget;
    }
    protected GameObject getToughest(float range)
    {
        GameObject furthestTarget = null;
        float highestHealth = 0;
        foreach (Collider target in Physics.OverlapSphere(transform.position, range, enemyMask))
        {

            if (target.gameObject.GetComponent<EnemyStats>().health > highestHealth)
            {
                highestHealth = target.gameObject.GetComponent<EnemyStats>().health;
                furthestTarget = target.gameObject;

            }
            
        }
        return furthestTarget;
    }



    IEnumerator ApplyBoosts()
    {

        damage = baseDamage * highestMagnification;
        range = baseRange * highestMagnification;
        attackrate = baseAttackRate * highestMagnification;


        
        highestMagnification = 1;

        yield return new WaitForSeconds(1.0f);

        StartCoroutine(ApplyBoosts());
    }
    IEnumerator Fire()
    {
        Debug.Log("Firing");

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
                firingtarget.GetComponent<EnemyStats>().health =- Mathf.Round(damage);
            }
            else
            {
                foreach(Collider target in Physics.OverlapSphere(firingtarget.transform.position, blastradius, enemyMask))
                {
                    firingtarget.GetComponent <EnemyStats>().health =- Mathf.Round(damage);
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
