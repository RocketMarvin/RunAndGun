using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSFX_Slider, volumeAmbience_Slider;
    public GameObject parent_Ambience, parent_SFX;
    public Toggle ambience_Toggle, sfx_Toggle;

    // Start is called before the first frame update
    void Start()
    {
        // Optionally, initialize the sliders with the current audio mixer values
        float sfxValue;
        audioMixer.GetFloat("SFXValue", out sfxValue);
        volumeSFX_Slider.value = Mathf.Pow(10, sfxValue / 20) * 100;

        float ambienceValue;
        audioMixer.GetFloat("AmbienceValue", out ambienceValue);
        volumeAmbience_Slider.value = Mathf.Pow(10, ambienceValue / 20) * 100;
    }

    // Update is called once per frame
    void Update()
    {
        // Optionally, update any visual feedback here
    }

    public void SFXToggle()
    {
        if(sfx_Toggle.isOn == true) parent_SFX.SetActive(true);
        else parent_SFX.SetActive(false);
    }

    public void MusicToggle()
    {
        if(ambience_Toggle.isOn == true) parent_Ambience.SetActive(true);
        else parent_Ambience.SetActive(false);
    }

    public void SFXSlider(float value)
    {
        if (value == 0)
        {
            audioMixer.SetFloat("SFXValue", -80); // Mute the SFX completely
        }
        else
        {
            audioMixer.SetFloat("SFXValue", Mathf.Log10(value / 100) * 20);
        }
    }

    public void MusicSlider(float value)
    {
        if (value == 0)
        {
            audioMixer.SetFloat("AmbienceValue", -80); // Mute the music completely
        }
        else
        {
            audioMixer.SetFloat("AmbienceValue", Mathf.Log10(value / 100) * 20);
        }
    }
}
