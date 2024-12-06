using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gameOverScript : MonoBehaviour
{
    public int baseHealth = 100;

    void Update()
    {
        if (baseHealth <= 0)
        {
            LoadGameOver(3);
        }
    }

    public void LoadGameOver(int buildindex)
    {
        SceneManager.LoadScene(buildindex);
    }
}
