using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public Text GameOverScoreText;
    public Text GameOverHighScoreText;

    public void RestartGame()
    {
        Destroy(GameObject.FindGameObjectWithTag("KinectObject"));
        SceneManager.LoadScene("ss");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void LoadMenu()
    {
        Destroy(GameObject.FindGameObjectWithTag("KinectObject"));
        SceneManager.LoadScene("MainMenu");
    }
    
        // Start is called before the first frame update
        void Start()
    {
        if (ManagerGamer.KinectObject != null||GameObject.FindGameObjectsWithTag("KinectObject").Length>1)
        {
            Destroy(GameObject.FindGameObjectWithTag("KinectObject"));
        }
        Time.timeScale = 1;
        Cursor.visible = true;
        ShowFinalResults();
    }
    void Update()
    {
        if (ManagerGamer.KinectObject != null || GameObject.FindGameObjectsWithTag("KinectObject").Length > 1)
        {
            Destroy(GameObject.FindGameObjectWithTag("KinectObject"));
        }
    }

    public void ShowFinalResults()
    {
        GameOverScoreText.text = ManagerGamer.score.ToString();
        GameOverHighScoreText.text = "High Score: "+ PlayerPrefs.GetInt("HighScore");
    }
}
