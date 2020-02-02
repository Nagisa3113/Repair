using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioClip gameOver;
    public AudioClip type;
    public AudioClip destroy;

    public AudioSource audio;

    private void Awake()
    {
        Instance = this;
        audio = GetComponent<AudioSource>();
    }

    public void PlayClip(AudioClip clip)
    {
        audio.Stop();
        audio.clip = clip;
        audio.Play();
    }

}
