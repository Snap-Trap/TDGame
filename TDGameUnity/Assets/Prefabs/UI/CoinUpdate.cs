using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinUpdate : MonoBehaviour
{
    public int coins;
    [SerializeField] private TextMeshProUGUI coinText;
    void Start()
    {
        //coinText = GetComponent<Text>();
        Debug.Log("Coins: " + coins);
    }

    void Update()
    {
        coinText.text = "Coins: " + coins;
    }
}
