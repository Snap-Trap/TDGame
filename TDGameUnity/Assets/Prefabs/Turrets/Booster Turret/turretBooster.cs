using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretBooster : turretBase, IUpgradeable
{
    [SerializeField] protected int[] magnificationLevels;

    public float statMagnification;

    [SerializeField] protected LayerMask towerMask;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Boost());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Boost ()
    {
       
        foreach(Collider tower in Physics.OverlapSphere(transform.position, range, towerMask)) 
        {
            Debug.Log("trying to boost" + tower.gameObject.name);
            if (tower.gameObject.GetComponent<turretOffense>() != null && tower.gameObject.GetComponent<turretOffense>().highestMagnification < statMagnification)
            {
                Debug.Log("boosting" + tower.gameObject.name);
                tower.gameObject.GetComponent<turretOffense>().highestMagnification = statMagnification;
            }

        }

        yield return new WaitForSeconds(1);

        StartCoroutine(Boost());
    }

    public void Upgrade()
    {
        level++;
    }
}
