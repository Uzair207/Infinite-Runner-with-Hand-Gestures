using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sounds{
    public string name;
    public AudioClip clip;
    public float volume;
    public bool loop;
    public AudioSource src;
}
