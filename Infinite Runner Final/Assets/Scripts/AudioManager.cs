using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour {

    public Sounds[] sounds;
    public static bool isPlaying;
	void Start () {
		foreach(Sounds s in sounds)
        {
            s.src= gameObject.AddComponent<AudioSource>();
            s.src.clip = s.clip;
            s.src.loop = s.loop;
        }
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            PlaySound("StartMenuTheme");
            StopSound("GameOverTheme");
        }
        else if(SceneManager.GetActiveScene().name=="ss")
        {
            StopSound("StartMenuTheme");
            PlaySound("CountDownSound");
            PlaySound("MainGameTheme");
            StopSound("GameOverTheme");
        }
        else
        {
            PlaySound("GameOverTheme");
        }

	}
	
    public void PlaySound(string name)
    {
        foreach (Sounds s in sounds)
        {
            if(s.name == name)
            {
                s.src.Play();
                
            }
        }
    }
    public void StopSound(string name)
    {
        foreach (Sounds s in sounds)
        {
            if (s.name == name)
            {
                s.src.Stop();
                
            }
        }
    }
    public void PauseSound(string name)
    {
        foreach(Sounds s in sounds)
        {
            if (s.name == name)
            {
                s.src.Pause();
            }
        }
    }
    public void ResumeSound(string name)
    {
        foreach (Sounds s in sounds)
        {
            if (s.name == name)
            {
                s.src.UnPause();
            }
        }
    }
}
