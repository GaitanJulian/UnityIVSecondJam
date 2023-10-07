using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerPanelControl : MonoBehaviour
{
    public AudioMixer mixer;
    public string parameterName = "MasterVolume";
    public Slider slider; // Volume Slider 

    private void Start()
    {
        slider.value = GetSliderValueFromParameter(GetParameterValue());
    }

    public void UpdateMixerParameter()
    {
        float sliderValue = slider.value;
        float remappedValue = Remap(sliderValue);
        SetParameterValue(remappedValue);
    }

    private void SetParameterValue(float value)
    {
        mixer.SetFloat(parameterName, value);
    }

    private float GetParameterValue()
    {
        float value;
        mixer.GetFloat(parameterName, out value);
        return value;
    }

    private float Remap(float value) // Remaps the value of the slider to smoothly adjust the volume
    {
        if (value <= 0.5f) return Mathf.Lerp(-40, -5, value * 2);
        else return Mathf.Lerp(-5, 10, value * 2 - 1);
    }

    private float GetSliderValueFromParameter(float parameterValue) // Inverse mapping for initial setup
    {
        if (parameterValue <= -5) return Mathf.InverseLerp(-40, -5, parameterValue) * 0.5f;
        else return 0.5f + 0.5f * Mathf.InverseLerp(-5, 10, parameterValue);
    }
}
