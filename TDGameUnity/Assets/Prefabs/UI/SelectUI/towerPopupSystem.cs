using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class towerPopupSystem : MonoBehaviour
{
    public GameObject tower;

    public Button upgradeButton;
    public Button sellButton;
    
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask towerLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the left mouse button was clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Check if the mouse was clicked over a UI element
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("clicking");
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                Debug.DrawRay(ray.origin, ray.direction, Color.red);
                if (Physics.Raycast(ray, out RaycastHit raycastHit))
                {
                    Debug.Log(raycastHit.transform.gameObject.layer);

                    if (raycastHit.transform.gameObject.CompareTag("Tower"))
                    {
                        Debug.Log("connecting");
                        GameObject upgradeTarget = raycastHit.transform.gameObject;
                        Vector3 targetPosition = upgradeTarget.transform.position;
                        tower = upgradeTarget;
                        transform.position = new Vector3(targetPosition.x, targetPosition.y + 3, targetPosition.z);
                        if (!raycastHit.transform.gameObject.GetComponent<turretBase>().isMaxLevel)
                        {
                            upgradeButton.GetComponentInChildren<TMP_Text>().text = "<b>Upgrade</b><br>$" + upgradeTarget.GetComponent<turretBase>().upgradeCosts[upgradeTarget.GetComponent<turretBase>().level - 1];
                        }
                        else
                        {
                            upgradeButton.GetComponentInChildren<TMP_Text>().text = "<b>Upgrade</b><br>MAX";
                        }
                        sellButton.GetComponentInChildren<TMP_Text>().text = "<b>Sell</b><br>$" + upgradeTarget.GetComponent<turretBase>().sellingPrice;
                    }
                }
                else
                {
                    transform.position = new Vector3(100, 100, 100);   
                }
            
                
            }
        }
    }
}
