using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinUpdate : MonoBehaviour
{
    public gameOverScript gameOverScript;
    public int coins;
    [SerializeField] private TextMeshProUGUI coinText, healthText;
    void Start()
    {
        //coinText = GetComponent<Text>();
        gameOverScript = GameObject.Find("EnemyDestination").GetComponent<gameOverScript>();
    }

    public void Update()
    {
        healthText.text = "Health: " + gameOverScript.baseHealth;
        coinText.text = "Coins: " + coins;
    }
}
