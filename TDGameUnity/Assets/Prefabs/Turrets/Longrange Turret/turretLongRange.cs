using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretLongRange : turretOffense, IUpgradeable
{

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Fire");
        StartCoroutine("ApplyBoosts");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Upgrade()
    {
        if (GameObject.Find("coinHolder").GetComponent<placeholderCoins>().coins >= upgradeCosts[level - 1])
        {
            GameObject.Find("coinHolder").GetComponent<placeholderCoins>().coins -= upgradeCosts[level - 1];
            level++;

            baseRange = rangeLevels[level-1];
            baseDamage = damageLevels[level-1];
            baseAttackRate = attackrateLevels[level-1];
            range = baseRange * highestMagnification;
            damage = baseDamage * highestMagnification;
            attackrate = baseAttackRate * highestMagnification;

            if (level == 3)
            {
                isMaxLevel = true;
            }
           
        }
    }
}
