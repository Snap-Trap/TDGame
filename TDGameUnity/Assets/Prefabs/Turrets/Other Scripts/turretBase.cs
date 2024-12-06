using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretBase : MonoBehaviour
{
    public int[] upgradeCosts;

    [SerializeField] protected int[] rangeLevels;

    public bool isMaxLevel;

    public int level;

    [SerializeField] protected float baseRange;

    public int sellingPrice;

    protected float range;
    public int cost;
    protected int costLevel1;
    protected int costLevel2;
    protected int costLevel3;

    // Start is called before the first frame update
    void Start()
    {
        sellingPrice += Mathf.RoundToInt(cost / 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
