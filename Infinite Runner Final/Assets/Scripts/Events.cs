using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject player;
    public GestureListener gestureListener;

    public void RestartGame()
    {
        Destroy(GameObject.FindGameObjectWithTag("KinectObject"));
        SceneManager.LoadScene("ss");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void ResumeGame()
    {
        PauseMenuUI.SetActive(false);
        player.GetComponent<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().ResumeSound("MainGameTheme");
        GameIsPaused = false;
    }
    void Pause()
    {

        PauseMenuUI.SetActive(true);
        player.GetComponent<Animator>().updateMode = AnimatorUpdateMode.Normal;
        Time.timeScale = 0f;
        FindObjectOfType<AudioManager>().PauseSound("MainGameTheme");
        GameIsPaused = true;
    }
    void Update()
    {
        if ((ManagerGamer.isGameStarted)&&(!ManagerGamer.gameOver))
        {
            if (Input.GetKeyDown(KeyCode.Escape)||gestureListener.isStopGesture())
            {
                if (GameIsPaused)
                {
                    ResumeGame();
                }
                else
                {
                    Pause();
                }
            }
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
}