using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesManager : MonoBehaviour {

    public int liveCounter;
    public int defaultLives;
    public static bool isLastObstacle;
    public GameObject[] lives;

    // Use this for initialization
    void Start()
    {
        isLastObstacle = false;
        defaultLives = 3;
        liveCounter = defaultLives;
    }

    // Update is called once per frame
    void Update()
    {
        if (liveCounter < 1)
        {
            ManagerGamer.gameOver = true;
        }
        if (liveCounter == 1)
        {
            isLastObstacle = true;
        }
    }

    public void DestroyLife()
    {
        liveCounter--;
        try
        {
            Destroy(lives[liveCounter]);
        }
        catch(System.Exception e)
        {
           // Debug.Log("Exception handled");
        }
    }
    public void AddLife()
    {
        liveCounter++;
    }
}
