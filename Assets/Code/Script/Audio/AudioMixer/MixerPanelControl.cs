    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Audio;
    using UnityEngine.UI;

    public class MixerPanelControl : MonoBehaviour
    {
        public AudioMixer mixer; // Referencia al AudioMixer
        public string parameterName = "MasterVolume";
        public Slider slider; // Referencia al Slider de la interfaz de usuario

        private void Start()
        {
            // Asegúrate de que el Slider muestre el valor actual del parámetro
            slider.value = GetParameterValue();
        }

        public void UpdateMixerParameter()
        {
            float sliderValue = slider.value;
            SetParameterValue(sliderValue);
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

    }
