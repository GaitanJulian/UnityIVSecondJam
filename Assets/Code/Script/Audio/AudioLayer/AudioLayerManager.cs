using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLayerManager : MonoBehaviour
{
    [SerializeField]
    private List<AudioLayer> audioLayers = new List<AudioLayer>();

    public AudioLayer CreateAudioLayer(string layerName, AudioSource audioSource)
    {
        AudioLayer layer = new AudioLayer { layerName = layerName, audioSource = audioSource };
        audioLayers.Add(layer);
        return layer;
    }

    public void RemoveAudioLayer(AudioLayer layer)
    {
        audioLayers.Remove(layer);
    }
}
