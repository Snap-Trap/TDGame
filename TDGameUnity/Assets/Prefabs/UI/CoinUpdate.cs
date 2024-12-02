using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinUpdate : MonoBehaviour
{
    public ManagerScript managerScript;
    private int coins;
    [SerializeField]
    private TextMeshProUGUI coinText;
    void Start()
    {
        //coinText = GetComponent<Text>();
        coins = managerScript.Coins;
        Debug.Log(coins);
    }

    void Update()
    {
        coinText.text = "Coins: " + coins;
    }
}
