using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class lineScript : MonoBehaviour
{
    private Vector3[] Positions;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Positions = new Vector3[] { new Vector3(0, 0, 0), new Vector3(transform.position.x, transform.position.y, transform.position.z) };

        GetComponent<LineRenderer>().SetPositions(Positions);


        
    }

    private void Fire()
}
