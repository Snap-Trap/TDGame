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
    public LayerMask whatIsGround;
    //private turretBase turretBase;

    void Start()
    {
        int Coins = coinUpdate.coins;
    }

    void Update()
    {
        if (PLacingTower != null)
        {
            // Makes the mouse only see the layer to prevent the mouse to contniuosly go up on the collision

            if (PLacingTower.layer == whatIsGround)
            {
                Ray camray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                if (Physics.Raycast(camray, out hitInfo, 100f))
                {
                    PLacingTower.transform.position = hitInfo.point;
                }
                if (click.triggered && hitInfo.collider.gameObject != null)
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
