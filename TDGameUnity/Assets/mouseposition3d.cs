using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseposition3d : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    private void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            transform.position = raycastHit.point;
        }
    }
}
