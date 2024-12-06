using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scuffedScript : MonoBehaviour
{
    void Start()
    {
        Debug.Log("This is a scuffed script");
        StartCoroutine(timer(3f));
    }

    IEnumerator timer(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(1);
    }

    void LoadScene(int buildindex)
    {
        SceneManager.LoadScene(buildindex);
    }
}
