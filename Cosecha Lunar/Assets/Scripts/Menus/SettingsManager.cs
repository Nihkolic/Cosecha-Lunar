using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Slider sensitivitySlider;

    [SerializeField] private AudioMixer mixer;
    private void Start()
    {
        PlayerPrefs.GetFloat("volume", 1f);
        PlayerPrefs.GetFloat("sensitivity", 2f);
    }
    public void SetLevel(float newVolume)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(newVolume) * 20);
        //PlayerPrefs.SetFloat("MusicVolume", sliderValue);
        PlayerPrefs.SetFloat("volume", newVolume);
    }
    public void SetSensitivity(float newSensitivity)
    {

        
        PlayerPrefs.SetFloat("volume", newSensitivity);
    }
}
