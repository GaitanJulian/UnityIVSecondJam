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
    [SerializeField] private AudioSource ambientStepSource;
    [SerializeField] private AudioSource ambientDarkSource;
    [SerializeField] private AudioSource ambientMusicSource;
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

    public AudioClip scream;
    //public AudioClip ambientClip;


    [Header("Sound Steps")]
    public AudioClip[] stepsClips;
    [Header("Sound of Music")]
    public AudioClip[] muiscPartClips;
    [Header("Sound Dark FX")]
    public AudioClip[] darkNoisesClips;



    private float minDelayDark = 16.0f;
    private float maxDelayDark = 64.0f;
    private float minDelayStep = 8.0f;
    private float maxDelayStep = 32.0f;
    private float minDelayMusic = 8.0f;
    private float maxDelayMusic = 16.0f;


    private void Awake()
    {
        /*// Implementación del patrón Singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Permite que el objeto AudioManager persista entre escenas.
        }
        else
        {
            Destroy(gameObject); // Si ya existe una instancia, destruye esta para mantener solo una.
            return;
        }*/

        StartCoroutine(PlayRandomSteps());
        StartCoroutine(PlayRandomDarkNoises());
        StartCoroutine(PlayRandomMusicPart());
    }
    /*
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
    }*/

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

    public void PlaySoundAmbient(AudioClip soundClip, int ambientSourceType)
    {
        
        if (ambientSourceType == 0)
        {
            ambientStepSource.clip = soundClip;
            ambientStepSource.Play();
            ambientStepSource.loop = false;
        }
        if (ambientSourceType == 1)
        {
            ambientDarkSource.clip = soundClip;
            ambientDarkSource.Play();
            ambientDarkSource.loop = false;
        }
        if(ambientSourceType == 2)
        {
            ambientMusicSource.clip = soundClip;
            ambientMusicSource.Play();
            ambientMusicSource.loop = false;
        }
    }
    

    public void StopSoundAmbient(int ambientSourceType) 
    { 
        if (ambientSourceType == 0) { ambientStepSource.Stop();}
        if (ambientSourceType == 1) {ambientDarkSource.Stop();}
        if (ambientSourceType == 2) {ambientMusicSource.Stop();}
    }

    public void PlayStepSound()
    {
        footstepsSource.clip = footstepsClip;
        footstepsSource.loop = true;
        footstepsSource.Play();
    }

    public void StopStepSound() {  footstepsSource.Stop(); }


    public void isWalking(bool Value) { if (!Value && footstepsSource.isPlaying) { StopStepSound(); } if (Value && !footstepsSource.isPlaying) { PlayStepSound(); } }

    private IEnumerator PlayRandomSteps()
    {
        while (true) // Repetir indefinidamente
        {
            if(stepsClips.Length >  0)
            {
                // Espera un tiempo aleatorio antes de reproducir el siguiente sonido
                yield return new WaitForSeconds(Random.Range(minDelayStep, maxDelayStep));

                int randomIndex = Random.Range(0, stepsClips.Length);
                AudioClip randomClip = stepsClips[randomIndex];

                // Modificar el nivel de paneo y la distancia de forma aleatoria
                float randomPan = Random.Range(-1f, 1f);
                float randomSpatialBlend = Random.Range(0f, 1f);

                // Configurar las propiedades de Audio Source
                ambientStepSource.panStereo = randomPan;
                //ambientStepSource.spatialBlend = randomSpatialBlend;

                // Reproducir el sonido aleatorio
                PlaySoundAmbient(randomClip, 0);
            }
            
        }
    }
    private IEnumerator PlayRandomDarkNoises()
    {
        if(darkNoisesClips.Length > 0)
        {
            while (true) // Repetir indefinidamente
            {
                // Espera un tiempo aleatorio antes de reproducir el siguiente sonido
                yield return new WaitForSeconds(Random.Range(minDelayDark, maxDelayDark));

                int randomIndex = Random.Range(0, darkNoisesClips.Length);
                AudioClip randomClip = darkNoisesClips[randomIndex];

                // Modificar el nivel de paneo y la distancia de forma aleatoria
                float randomPan = Random.Range(-1f, 1f);
                float randomSpatialBlend = Random.Range(0f, 1f);

                // Configurar las propiedades de Audio Source
                ambientDarkSource.panStereo = randomPan;
                ambientDarkSource.spatialBlend = randomSpatialBlend;

                // Reproducir el sonido aleatorio
                PlaySoundAmbient(randomClip, 1);
            }
        }
        
    }
    private IEnumerator PlayRandomMusicPart()
    {
        if(muiscPartClips.Length > 0)
        {
            while (true) // Repetir indefinidamente
            {
                // Espera un tiempo aleatorio antes de reproducir el siguiente sonido
                yield return new WaitForSeconds(Random.Range(minDelayMusic, maxDelayMusic));

                int randomIndex = Random.Range(0, muiscPartClips.Length);
                AudioClip randomClip = muiscPartClips[randomIndex];

                // Modificar el nivel de paneo y la distancia de forma aleatoria
                float randomPan = Random.Range(-1f, 1f);
                float randomSpatialBlend = Random.Range(0f, 1f);

                // Configurar las propiedades de Audio Source
                ambientMusicSource.panStereo = randomPan;
                ambientMusicSource.spatialBlend = randomSpatialBlend;

                // Reproducir el sonido aleatorio
                PlaySoundAmbient(randomClip, 2);
            }
        }
        
    }
}
