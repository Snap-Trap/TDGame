using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretLongRange : turretOffense
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Fire", 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
