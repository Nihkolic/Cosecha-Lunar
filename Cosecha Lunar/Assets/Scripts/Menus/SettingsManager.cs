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

    private float sensitivity;
    private float volume;

    private const string SensitivityKey = "Sensitivity";
    private const string VolumeKey = "Volume";
    private void Start()
    {
        sensitivity = PlayerPrefs.GetFloat(SensitivityKey, 1f);
        volume = PlayerPrefs.GetFloat(VolumeKey, 0.5f);

        sensitivitySlider.value = sensitivity;
        volumeSlider.value = volume;
    }
    public void SetLevel(float newVolume)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(newVolume) * 20);
        //PlayerPrefs.SetFloat("MusicVolume", sliderValue);
        PlayerPrefs.SetFloat("volume", newVolume);
    }
    public void SetSensitivity(float value)
    {
        sensitivity = value;
        // Save sensitivity to PlayerPrefs
        PlayerPrefs.SetFloat(SensitivityKey, sensitivity);
    }

    public void SetVolume(float value)
    {
        volume = value;
        // Save volume to PlayerPrefs
        PlayerPrefs.SetFloat(VolumeKey, volume);
    }
}
