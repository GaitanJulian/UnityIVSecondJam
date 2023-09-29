using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    [Header("Audio Source")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource soundEffectSource;
    [SerializeField] private AudioSource footstepsSource;
    [SerializeField] private AudioSource breathingSource;
    [SerializeField] private AudioSource heartBeatingSource;
    //[SerializeField] private AudioSource  ;


    [Header("Audio Clip")]
    //public AudioClip clickSound;
    //public AudioClip rollOver;
    //public AudioClip switchSound;
    public AudioClip musicBackground;

    //public AudioClip jumpSound;
    //public AudioClip dieSound;
    //public AudioClip transformationSound;
    //public AudioClip coinSound;

    public AudioClip footstepsClip;
    public AudioClip breathingClip;
    public AudioClip heartBeatingClip;
    // public AudioClip ambientClip;


    private void Awake()
    {
        // Implementación del patrón Singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Permite que el objeto AudioManager persista entre escenas.
        }
        else
        {
            Destroy(gameObject); // Si ya existe una instancia, destruye esta para mantener solo una.
            return;
        }
    }

    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("AudioManager is missing in the scene.");
            }
            return instance;
        }
    }

    private void Start()
    {
        musicSource.clip = musicBackground;
        musicSource.Play();

        heartBeatingSource.clip = footstepsClip;
        heartBeatingSource.Play();

        breathingSource.clip = breathingClip;
        breathingSource.Play();

        footstepsSource.clip = footstepsClip;  
        footstepsSource.Play();

    }
    public void PlayBackgroundMusic()
    {
        if (!musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }


    public void StopBackgroundMusic()
    {
        musicSource.Stop();
    }

    public void PlaySoundEffect(AudioClip soundClip)
    {
        soundEffectSource.clip = soundClip;
        soundEffectSource.Play();
    }

    public void StopSoundEffect()
    {
        soundEffectSource.Stop();
    }

    public void BreathChange(AudioClip soundClip)
    {
        breathingSource.clip = soundClip;
        soundEffectSource.Play();
    }

    
}
