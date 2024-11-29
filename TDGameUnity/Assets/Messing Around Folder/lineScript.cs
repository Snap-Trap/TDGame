using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class lineScript : MonoBehaviour
{
    private Vector3[] Positions;
    private float t;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<LineRenderer>().SetWidth(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Positions = new Vector3[] { new Vector3(0, 0, 0), transform.position };

        GetComponent<LineRenderer>().SetPositions(Positions);

        if (Input.GetMouseButton(0))
        {

            GetComponent<LineRenderer>().SetWidth(t * 100, t * 100);
            t += Time.deltaTime;

        }

    }
}


