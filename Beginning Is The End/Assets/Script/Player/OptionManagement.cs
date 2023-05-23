using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;

public class OptionManagement : MonoBehaviour
{
    [Header("Graphisme Menu")]
    [SerializeField]
    private Image OptionPopUp;

    [SerializeField]
    private TMP_Dropdown resolutionDropdown;

    [SerializeField]
    private TMP_Dropdown QualityDropdown;

    [SerializeField]
    private AudioMixer audioMixer;

    void Start()
    {
        Resolution[] resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> resolutionOptions = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            resolutionOptions.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(resolutionOptions);
        resolutionDropdown.value = currentResolutionIndex;

        resolutionDropdown.RefreshShownValue();
        
        string[] qualityNames = QualitySettings.names;
        QualityDropdown.ClearOptions();


        List<string> qualityOptions = new List<string>();
        int currentQualityIndex = 0;

        for (int i = 0; i < qualityNames.Length; i++)
        {
            string option = qualityNames[i];
            qualityOptions.Add(option);
            if (QualitySettings.GetQualityLevel() == i)
            {
                currentQualityIndex = i;
            }
        }

        QualityDropdown.AddOptions(qualityOptions);
        QualityDropdown.value = currentQualityIndex;

        QualityDropdown.RefreshShownValue();
    }

    public void setResolution(int resolutionIndex)
    {
        Resolution resolutions = Screen.resolutions[resolutionIndex];
        Screen.SetResolution(resolutions.width, resolutions.height, Screen.fullScreen);
    }

    public void setFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void setMasterVolume(float volume)
    {
        audioMixer.SetFloat("Master", volume);
    }
    
    public void setGameplayVolume(float volume)
    {
        audioMixer.SetFloat("Gameplay", volume);
    }
    
    public void setAmbiantVolume(float volume)
    {
        audioMixer.SetFloat("Ambiant", volume);
    }
    
    public void setMusicVolume(float volume)
    {
        audioMixer.SetFloat("Music", volume);
    }

    public void setQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void GraphismeMenu()
    {
        OptionPopUp.gameObject.SetActive(true);
    }
}
