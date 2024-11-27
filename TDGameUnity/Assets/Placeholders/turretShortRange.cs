using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretShortRange : turretOffense
{
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Fire");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
