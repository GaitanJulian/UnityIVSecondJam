using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioSource soundEffect;

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

    public void PlayBackgroundMusic()
    {
        if (!backgroundMusic.isPlaying)
        {
            backgroundMusic.Play();
        }
    }

    public void StopBackgroundMusic()
    {
        backgroundMusic.Stop();
    }

    public void PlaySoundEffect(AudioClip soundClip)
    {
        soundEffect.clip = soundClip;
        soundEffect.Play();
    }

    public void StopSoundEffect()
    {
        soundEffect.Stop();
    }
}
