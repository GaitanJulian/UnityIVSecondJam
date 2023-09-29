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
    [SerializeField] private AudioSource ambientSource;
    [SerializeField] private AudioSource noiseSourse;



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
    public AudioClip noiseClip;
    //public AudioClip ambientClip;


    [Header("Sound Clips")]
    public AudioClip[] soundClips;


    private float minDelay = 8.0f;
    private float maxDelay = 32.0f;


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

        StartCoroutine(PlayRandomSounds());
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

        noiseSourse.clip = noiseClip;
        noiseSourse.Play();

        heartBeatingSource.clip = heartBeatingClip;
        heartBeatingSource.Play();

        breathingSource.clip = breathingClip;
        breathingSource.Play(); 
    }

   
    public void PlayBackgroundMusic(){if (!musicSource.isPlaying){musicSource.Play();}}

    public void StopBackgroundMusic(){ musicSource.Stop();}

    public void PlaySoundEffect(AudioClip soundClip)
    {
        soundEffectSource.clip = soundClip;
        soundEffectSource.Play();
        soundEffectSource.loop = false;
    }

    public void StopSoundEffect(){soundEffectSource.Stop();}

    public void PlaySoundAmbient(AudioClip soundClip)
    {
        soundEffectSource.clip = soundClip;
        soundEffectSource.Play();
        soundEffectSource.loop = false;
    }

    public void StopSoundAmbient() { soundEffectSource.Stop(); }

    public void PlayStepSound()
    {
        footstepsSource.clip = footstepsClip;
        footstepsSource.loop = true;
        footstepsSource.Play();
    }

    public void StopStepSound() {  footstepsSource.Stop(); }


    public void isWalking(bool Value) { if (!Value && footstepsSource.isPlaying) { StopStepSound(); } if (Value && !footstepsSource.isPlaying) { PlayStepSound(); } }

    private IEnumerator PlayRandomSounds()
    {
        while (true) // Repetir indefinidamente
        {
            // Espera un tiempo aleatorio antes de reproducir el siguiente sonido
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));

            int randomIndex = Random.Range(0, soundClips.Length);
            AudioClip randomClip = soundClips[randomIndex];

            // Modificar el nivel de paneo y la distancia de forma aleatoria
            float randomPan = Random.Range(-1f, 1f);
            float randomSpatialBlend = Random.Range(0f, 1f);

            // Configurar las propiedades de Audio Source
            ambientSource.panStereo = randomPan;
            ambientSource.spatialBlend = randomSpatialBlend;

            // Reproducir el sonido aleatorio
            PlaySoundAmbient(randomClip);
        }
    }
}
