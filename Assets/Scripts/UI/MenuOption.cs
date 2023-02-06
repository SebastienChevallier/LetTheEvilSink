using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuOption : MonoBehaviour
{
    public So_Parametres parametres;
    
    [Header("UI")]
    public Slider sliderVolume;
    public Slider sliderVolumeMusic;
    public Slider sliderVolumeSound;
    public Slider sliderBrightness;
    public Slider sliderSensitivity;
    public Toggle toggleFullscreen;
    
    public TMP_Dropdown dropdownResolution;

    private void Start()
    {
        LoadValue();
        SetValue();
    }

    public void Return()
    {
        GetValue();
        SaveValue();
        
        SceneManager.UnloadSceneAsync(2);
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }
    
    //Get Value from all sliders
    private void GetValue()
    {
        parametres.volumeGeneral = sliderVolume.value;
        parametres.volumeMusic = sliderVolumeMusic.value;
        parametres.volumeSound = sliderVolumeSound.value;
        parametres.brightness = sliderBrightness.value;
        parametres.sensitivity = sliderSensitivity.value;
        parametres.fullscreen = toggleFullscreen.isOn;
        
        string[] resolution = dropdownResolution.options[dropdownResolution.value].text.Split('x');
        
        parametres.resolutionX = float.Parse(resolution[0]);
        parametres.resolutionY = float.Parse(resolution[1]);
    }
    
    private void SetValue()
    {
        sliderVolume.value = parametres.volumeGeneral;
        sliderVolumeMusic.value = parametres.volumeMusic;
        sliderVolumeSound.value = parametres.volumeSound;
        sliderBrightness.value = parametres.brightness;
        sliderSensitivity.value = parametres.sensitivity;
        toggleFullscreen.isOn = parametres.fullscreen;
    }
    
    
    //Save value to PlayerPrefs
    private void SaveValue()
    {
        PlayerPrefs.SetFloat("Volume", parametres.volumeGeneral);
        PlayerPrefs.SetFloat("VolumeMusic", parametres.volumeMusic);
        PlayerPrefs.SetFloat("VolumeSound", parametres.volumeSound);
        PlayerPrefs.SetFloat("Brightness", parametres.brightness);
        PlayerPrefs.SetFloat("Sensitivity", parametres.sensitivity);
        PlayerPrefs.SetFloat("ResolutionX", parametres.resolutionX);
        PlayerPrefs.SetFloat("ResolutionY", parametres.resolutionY);
        PlayerPrefs.SetInt("Fullscreen", parametres.fullscreen ? 1 : 0);
    }
    
    
    
    private void LoadValue()
    {
        if(!PlayerPrefs.HasKey("Volume"))
        {
            PlayerPrefs.SetFloat("Volume", 1);
            PlayerPrefs.SetFloat("VolumeMusic", 1);
            PlayerPrefs.SetFloat("VolumeSound", 1);
            PlayerPrefs.SetFloat("Brightness", 1);
            PlayerPrefs.SetFloat("Sensitivity", 1);
            PlayerPrefs.SetFloat("ResolutionX", 1920);
            PlayerPrefs.SetFloat("ResolutionY", 1080);
            PlayerPrefs.SetInt("Fullscreen", 1);
        }
        parametres.volumeGeneral = PlayerPrefs.GetFloat("Volume");
        parametres.volumeMusic = PlayerPrefs.GetFloat("VolumeMusic");
        parametres.volumeSound = PlayerPrefs.GetFloat("VolumeSound");
        parametres.brightness = PlayerPrefs.GetFloat("Brightness");
        parametres.sensitivity = PlayerPrefs.GetFloat("Sensitivity");
        parametres.resolutionX = PlayerPrefs.GetFloat("ResolutionX");
        parametres.resolutionY = PlayerPrefs.GetFloat("ResolutionY");
        parametres.fullscreen = PlayerPrefs.GetInt("Fullscreen") == 1;
    }
    
    
}
