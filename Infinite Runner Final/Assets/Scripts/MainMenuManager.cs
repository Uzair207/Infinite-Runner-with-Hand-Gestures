using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {
    void Start()
    {
        Time.timeScale = 1;

    }
    public void StartGame()
    {
        Destroy(GameObject.FindGameObjectWithTag("KinectObject"));
        SceneManager.LoadScene("ss");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
