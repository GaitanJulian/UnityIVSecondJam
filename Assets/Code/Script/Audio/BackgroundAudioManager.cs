using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudioManager : MonoBehaviour
{
    

    [Header("BackgroundMusic")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioClip musicClip;

    private void Start()
    {
        musicSource.clip = musicClip;
        musicSource.Play();
        musicSource.loop = true;
        musicSource.playOnAwake = true;
    }

    public void PlayBackgroundMusic()
    {
        if (!musicSource.isPlaying)
        {
            musicSource.Play();
            musicSource.loop = true;
            musicSource.playOnAwake = true;
        }
    }
    public void ChangerBackgroundMusic(AudioClip clip)
    {
        if (!musicSource.isPlaying)
        {
            musicSource.clip = musicClip;
            PlayBackgroundMusic();
        }
        if (musicSource.isPlaying)
        {
            StopBackgroundMusic();
            ChangerBackgroundMusic(clip);
        }
    }
    public void StopBackgroundMusic()
    {
        musicSource.Stop();
    }
}
