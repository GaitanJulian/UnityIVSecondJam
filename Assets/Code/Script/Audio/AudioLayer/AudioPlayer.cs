using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioLayerManager layerManager;

    public void PlaySoundInLayer(AudioClip soundClip, AudioLayer layer)
    {
        layer.audioSource.clip = soundClip;
        layer.audioSource.Play();
        layer.audioSource.loop = false;
    }

    public void StopSoundInLayer(AudioLayer layer)
    {
        layer.audioSource.Stop();
    }
}
