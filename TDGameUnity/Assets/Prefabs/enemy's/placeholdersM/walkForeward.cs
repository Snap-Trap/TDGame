using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkforeward : MonoBehaviour
{
    [SerializeField]
    private float speed; // Speed of the character

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(3, 3, 3);
    }

    // Update is called once per frame
    void Update()
    {
        // Move the character forward along the z-axis
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}