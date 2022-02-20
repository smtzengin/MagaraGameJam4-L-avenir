using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound
{
    public string name;

    public AudioClip clip;

    [Range(0.1f, 1f)]
    public float volume;

    [Range(-1f, 3f)]
    public float pitch;

    
    public AudioSource source;

    public bool loop;

}
