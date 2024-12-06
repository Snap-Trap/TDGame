using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class sellingScript : MonoBehaviour
{

    [SerializeField] private GameObject towerPopup;
    [SerializeField] private GameObject coinUpdater;

    private GameObject sellTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {

        GameObject sellTarget = towerPopup.GetComponent<towerPopupSystem>().tower;
        Debug.Log("attempting to sell");
        sellTarget.GetComponent<IUpgradeable>().Sell();
        coinUpdater.GetComponent<CoinUpdate>().coins += sellTarget.GetComponent<turretBase>().sellingPrice;
        towerPopup.transform.position = new Vector3(100,100,100);
    }

    public void sellUpdate()
    {
        GameObject sellTarget = towerPopup.GetComponent<towerPopupSystem>().tower;

        GetComponentInChildren<TMP_Text>().text = "<b>Sell</b><br>$" + sellTarget.GetComponent<turretBase>().sellingPrice;
    }
}
