using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public static BGMManager instance;
    public AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(AudioClip music)
    {
        // Check if there's an active Audio Source to play music
        if (audioSource != null)
        {
            audioSource.Stop();
            audioSource.clip = music;
            audioSource.Play();
        }
    }
}
