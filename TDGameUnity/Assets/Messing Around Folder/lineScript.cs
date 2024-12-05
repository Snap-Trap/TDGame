using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class lineScript : MonoBehaviour
{
    public bool thickening;

    public GameObject target;

    private bool firing;
    public float width;

    private Vector3[] Positions;

    private LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        width = 0;

        lineRenderer = GetComponent<LineRenderer>();

        
    }

    // Update is called once per frame
    void Update()
    {
        Positions = new Vector3[] { new Vector3(0, 0, 0), target.transform.position };

        lineRenderer.SetPositions(Positions);



        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            StartCoroutine(Fire());   
        }
        
    }

    IEnumerator Fire()
    {
        lineRenderer.SetWidth(0.5f, 0.5f);

        yield return new WaitForSeconds(0.3f);

        lineRenderer.SetWidth(0, 0);
    }
}
