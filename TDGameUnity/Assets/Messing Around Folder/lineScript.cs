using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class lineScript : MonoBehaviour
{
    public bool thickening;

    private bool firing;
    public float width;

    private Vector3[] Positions;
    // Start is called before the first frame update
    void Start()
    {
        width = 0;
        GetComponent<LineRenderer>().SetWidth(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Positions = new Vector3[] { new Vector3(0, 0, 0), new Vector3(transform.position.x, transform.position.y, transform.position.z) };

        GetComponent<LineRenderer>().SetPositions(Positions);



        if (Input.GetKeyDown(KeyCode.Space)) 
        {

            for (int i = 0; i < 200; i++)
            {
                if (thickening)
                {
                    Debug.Log(width);
                    width += 0.01f;
                    GetComponent<LineRenderer>().SetWidth(width, width);
                    if (width > 1)
                    {
                        thickening = false;
                    }
                }

                if (!thickening)
                {
                    width -= 0.01f;
                    GetComponent<LineRenderer>().SetWidth(width, width);
                    if (width < 0)
                    {
                        thickening = true;
                    }
                }
            }
        }
        if (firing)
        {

        }
        
    }

    private void Fire()
    {
        for (int i = 0; i < 200;  i++)
        {
            if (thickening)
            {
                Debug.Log(width);
                width += 0.01f;
                GetComponent<LineRenderer>().SetWidth(width, width);
                if (width > 1)
                {
                    thickening = false;
                }
            }

            if (!thickening)
            {
                width -= 0.01f;
                GetComponent<LineRenderer>().SetWidth(width, width);
                if (width < 0)
                {
                    thickening = true;
                }
            }
        }
    }
}
