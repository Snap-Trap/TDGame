using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretShortRange : turretOffense
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
}
