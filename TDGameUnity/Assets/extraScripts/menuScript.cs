using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
    public GameObject mainMenuUI;

    private void Start()
    {
        mainMenuUI.SetActive(true);
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
