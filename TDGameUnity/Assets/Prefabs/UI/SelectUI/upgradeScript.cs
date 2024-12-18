using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class upgradeScript : MonoBehaviour
{
    [SerializeField] private GameObject towerPopup;
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
        GameObject upgradeTarget = towerPopup.GetComponent<towerPopupSystem>().tower;
        if (!upgradeTarget.GetComponent<turretBase>().isMaxLevel)
        {

            upgradeTarget.GetComponent<IUpgradeable>().Upgrade();
            if (!upgradeTarget.GetComponent<turretBase>().isMaxLevel)
            {
                GetComponentInChildren<TMP_Text>().text = "<b>Upgrade</b><br>$" + upgradeTarget.GetComponent<turretBase>().upgradeCosts[upgradeTarget.GetComponent<turretBase>().level - 1];
            }
            else
            {
                GetComponentInChildren<TMP_Text>().text = "<b>Upgrade</b><br>MAX";
            }

        }
        else
        {
            GetComponentInChildren<TMP_Text>().text = "<b>Upgrade</b><br>MAX";
        }
    }
}
