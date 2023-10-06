using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class BrightnessAdjustment : MonoBehaviour
{
    public Volume postProcessVolume;
    private ColorAdjustments colorAdjustments;
    public Slider brightnessSlider;

    private void Start()
    {
        postProcessVolume.profile.TryGet(out colorAdjustments);
        brightnessSlider.onValueChanged.AddListener(AdjustBrightness);
    }

    public void AdjustBrightness(float sliderValue)
    {
        float minExposure = -0.5f;
        float maxExposure = 0.5f;

        float exposureValue = Mathf.Lerp(minExposure, maxExposure, sliderValue);
        colorAdjustments.postExposure.value = exposureValue;
    }
}
