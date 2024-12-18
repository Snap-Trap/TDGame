using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class towerButtons : MonoBehaviour
{
    public InputAction click;
    public CoinUpdate coinUpdate;
    [SerializeField] private GameObject PlayerCamera;
    private GameObject PLacingTower;
    [SerializeField] private int towerCost;
    //private turretBase turretBase;

    void Start()
    {
        int Coins = coinUpdate.coins;
    }

    void Update()
    {
        if (PLacingTower != null)
        {

            Ray camray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(camray, out hitInfo, 100f))
            {
                PLacingTower.transform.position = hitInfo.point;
            }
            if (click.triggered && hitInfo.collider.gameObject.CompareTag("groundTag"))
            {
                //if (hitInfo.collider.gameObject.tag != "cantplace")
                //{
                if (coinUpdate.coins >= towerCost)
                {
                    coinUpdate.coins -= towerCost;
                    PLacingTower = null;
                }
                //}
            }
        }
    }
    public void SetTowerLocation(GameObject tower)
    {
        PLacingTower = Instantiate(tower, Vector3.zero, Quaternion.identity);
    }

    void OnEnable()
    {
        click.Enable();
    }

    void OnDisable()
    {
        click.Disable();
    }
}
