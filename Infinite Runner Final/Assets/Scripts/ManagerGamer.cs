using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ManagerGamer : MonoBehaviour {

    public static bool gameOver;
    public static bool isGameStarted;
    public GameObject gameOverCanvas;
    public static int noOfCoins;
    public static int score;
    public Text coinsText;
    public Text scoreText;
    public Text highScoreText;
    public Animator anim;
    public GameObject MainGameCanvas;
    public static GameObject KinectObject;
    public Animator GameOverTextanim;

    void Start() {
        gameOver = false;
        isGameStarted = false;
        AudioManager.isPlaying = false;
        Time.timeScale = 1;
        noOfCoins = 0;
        score = 0;
        highScoreText.text ="High Score: "+ PlayerPrefs.GetInt("HighScore", 0).ToString();
        Cursor.visible = false;
        KinectObject = GameObject.FindGameObjectWithTag("KinectObject");
    }

    // Update is called once per frame
    void Update() {
        Cursor.visible = false;

        if (gameOver)
        {
            anim.SetBool("isDead", true);
            if (!AudioManager.isPlaying)
            {
                FindObjectOfType<AudioManager>().StopSound("MainGameTheme");
                FindObjectOfType<AudioManager>().PlaySound("GameOver");
                AudioManager.isPlaying = true;
            }
          //  Destroy(GameObject.FindGameObjectWithTag("KinectObject"));
            MainGameCanvas.SetActive(false);
            gameOverCanvas.SetActive(true);
            GameOverTextanim.SetTrigger("show");
            GameOverTextanim.SetTrigger("hide");
            StartCoroutine(GameOverScene(5f));
            
            
        }

        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = "High Score: " + score;
        }
        scoreText.text = "Score: " + score;


        coinsText.text = "" + noOfCoins;


    }
    private IEnumerator GameOverScene(float p)
    {
        Time.timeScale = 0;
        float gameEndTime = Time.realtimeSinceStartup + p;
        while (Time.realtimeSinceStartup < gameEndTime)
        {
            yield return 0;
        }
        SceneManager.LoadScene("GameOver");
    }
    public void ResetHighScore()
    {
        PlayerPrefs.DeleteAll();
        score = 0;
        highScoreText.text = "0";
    }
    




}
