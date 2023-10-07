using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    [SerializeField] private AudioSource soundEffectSource;

    public void PlaySoundEffect(AudioClip soundClip)
    {
        soundEffectSource.clip = soundClip;
        soundEffectSource.Play();
        soundEffectSource.loop = false;
    }

    public void StopSoundEffect()
    {
        soundEffectSource.Stop();
    }
}
